using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheChase.Classes;

namespace TheChase.Server
{
    public class NetworkHandler
    {
        public Server Form;
        public Dictionary<uint, Connection> Connections = new Dictionary<uint, Connection>();

        public event EventHandler<User> UserJoined;

        Thread newConThread;
        public TcpListener LISTENER = new TcpListener(IPAddress.Any, Connection.PORT);
        public NetworkHandler(Server form)
        {
            Form = form;
            LISTENER.Start();
            newConThread = new Thread(newClientHandle);
            newConThread.Start();
        }

        bool _listen = true;
        public bool Listening
        {
            get
            {
                return _listen;
            }
            set
            {
                if(_listen && !value)
                { // setting false
                    LISTENER.Start();
                } else if (value && !_listen)
                { // setting true
                    LISTENER.Stop();
                }
                _listen = value;
            }
        }

        public void Broadcast(Packet packet)
        {
            string s = packet.ToString();
            Logger.LogMsg($"S/Broadcast: {s}", LogSeverity.Debug);
            lock(Connections)
            {
                foreach(var usr in Connections.Values)
                {
                    usr.Send(s);
                }
            }
        }

        void newClientHandle()
        {
            try
            {
                do
                {
                    TcpClient client = LISTENER.AcceptTcpClient();
                    Logger.LogMsg("New TcpClient connected");
                    var stream = client.GetStream();
                    var bytes = new Byte[client.ReceiveBufferSize];
                    stream.Read(bytes, 0, bytes.Length);
                    var data = Encoding.UTF8.GetString(bytes);

                    data = data.Replace("\0", "").Trim();
                    data = data.Substring(1, data.Length - 2);

                    var nClient = new User();
                    nClient.Id = Common.USER_ID++;
                    nClient.Name = data;
                    Logger.LogMsg($"New User: '{data}' ({nClient.Id})");
                    Common.Users[nClient.Id] = nClient;
                    var conn = new Connection(nClient.Id.ToString(), HandleConnDisconnect);
                    Connections[nClient.Id] = conn;
                    conn.Client = client;
                    conn.Listen();
                    conn.Receieved += Conn_Receieved;
                    var identity = new Packet(PacketId.GiveIdentity, nClient.ToObject());
                    conn.Send(identity.ToString());

                    Broadcast(new Packet(PacketId.UserJoined, nClient.ToObject()));
                    foreach (var id in Connections.Keys)
                    {
                        if (Common.Users.TryGetValue(id, out var user))
                        {
                            // logically, this should be UserJoined, but for some reason
                            // that doesnt work, yet this does; so...
                            var packet = new Packet(PacketId.UserJoined, user.ToObject());
                            conn.Send(packet.ToString());
                        }
                    }

                    Form.Invoke(new Action(() =>
                    {
                        UserJoined?.Invoke(this, nClient);
                    }));
                } while (_listen);
            } catch (SocketException ex)
            {
                Logger.LogMsg(ex.ToString(), LogSeverity.Error);
            }
        }

        private void Conn_Receieved(object sender, string e)
        {
            if(!(sender is Connection conn && uint.TryParse(conn.Reference, out var id) && Common.Users.TryGetValue(id, out var user)))
                return;
            Logger.LogMsg($"SREC/{conn.Reference}: {e}", LogSeverity.Debug);
            var packet = new Packet(e);
            try
            {
                HandlePacket(conn, user, packet);
            } catch (Exception ex)
            {
                Logger.LogMsg($"ERR/{conn.Reference}: {ex}", LogSeverity.Error);
            }
        }

        void HandlePacket(Connection conn, User user, Packet packet)
        {
            if(packet.Id == PacketId.RequestRole)
            {
                var chr = packet.Content["r"].ToObject<char>();
                Form.CurrentGame.Swap(user, chr);
                Form.Invoke(new Action(() =>
                {
                    Form.UpdateUserList();
                }));
                Broadcast(new Packet(PacketId.SendGameState, Form.CurrentGame.ToObject()));
            } else if(packet.Id == PacketId.ReadyMB)
            {
                var game = Form.CurrentGame;
                if (game.Stage != GameStage.MoneyBuilders) return;
                var q = QUESTIONS.GetOpen();

            }
        }

        private Task HandleConnDisconnect(Connection connection, Exception error)
        {
            if (uint.TryParse(connection.Reference, out var id))
            {
                if (Common.Users.TryGetValue(id, out var user))
                {
                    Connections.Remove(id);
                    // Dont remove from users, since that might be helpful to keep
                    Logger.LogMsg($"Disconnect on {id} {user.Name}");
                    Form.Invoke(new Action(() => {
                        var leftPacket = new Packet(PacketId.UserLeft, user.ToObject());
                        Broadcast(leftPacket);
                    }));
                    return Task.CompletedTask;
                }
            }
            Logger.LogMsg($"Disconnect on {id}, no user available.");
            return Task.CompletedTask;
        }
    }
}
