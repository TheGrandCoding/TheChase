using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheChase.Classes;

namespace TheChase.Client
{
    public class ClientConnection : Connection
    {
        MainClient MainForm;
        public event EventHandler<User> SelfIdentity;
        public event EventHandler<User> UserJoined;
        public event EventHandler<User> UserDisconnect;
        public event EventHandler<Classes.Game> GameUpdate;
        public event EventHandler<Classes.MoneyBuilderQ> NewMoneyBuilder;
        public ClientConnection(MainClient form, string name, Func<Connection, Exception, Task> callback) : base(name, callback)
        {
            MainForm = form;
            this.Receieved += ClientConnection_Receieved;
        }

        public Task Connect(IPAddress addr)
        {
            if(Client == null)
            {
                Client = new System.Net.Sockets.TcpClient(System.Net.Sockets.AddressFamily.InterNetwork);
            }
            return Client.ConnectAsync(addr, PORT);
        }

        private void ClientConnection_Receieved(object sender, string e)
        {
            var packet = new Packet(e);
            Logger.LogMsg(new LogMessage()
            {
                Content = packet.ToString(),
                Error = null,
                Location = $"Client/REC/{this.Reference}",
                Severity = LogSeverity.Debug
            });
            if(packet.Id == PacketId.GiveIdentity)
            {
                var usr = new User(packet.Content);
                MainForm.Invoke(new Action(() => { SelfIdentity?.Invoke(this, usr); }));
            } else if (packet.Id == PacketId.UserJoined)
            {
                var usr = new User(packet.Content);
                MainForm.Invoke(new Action(() => { UserJoined?.Invoke(this, usr); }));
            } else if (packet.Id == PacketId.SendGameState)
            {
                var game = new Classes.Game(packet.Content);
                MainForm.Invoke(new Action(() => { GameUpdate?.Invoke(this, game); }));
            } else if (packet.Id == PacketId.Disconnect)
            {
                MainForm.Invoke(new Action(() =>
                {
                    this.Close(new Exception(packet.Content["reason"].ToObject<string>()));
                }));
            } else if (packet.Id == PacketId.NewMBQuestion)
            {
                var moneyB = new MoneyBuilderQ(packet.Content);
                MainForm.Invoke(new Action(() =>
                {
                    this.NewMoneyBuilder.Invoke(this, moneyB);
                }));
            } 
            else
            {
                MainForm.Invoke(new Action(() =>
                {
                    System.Windows.Forms.MessageBox.Show(packet.ToString(), "Unknown Packet", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }));
            }
        }
    }
}
