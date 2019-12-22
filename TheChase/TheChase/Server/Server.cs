using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheChase.Classes;

namespace TheChase.Server
{
    public partial class Server : Form
    {
        public NetworkHandler NETWORK;
        public Classes.MasterlistServer MLServer;
        public Server()
        {
            InitializeComponent();
        }

        Thread rlMLThread = null;

        void handleMLReturn(Classes.MasterlistServer server)
        {
            rlMLThread = null;
            MLServer = server;
            if(server == null)
            {
                this.Text = "Failed to Host, see logs";
            } else
            {
                this.Text = $"Server Hosted on ML";
            }
        }

        async void RLMasterList()
        {
            if (!this.InvokeRequired)
            {
                if (rlMLThread != null)
                    return;
                rlMLThread = new Thread(RLMasterList);
                rlMLThread.Start();
                return;
            }
            // we should now be running on a different thead to the UI
            try
            {
                if(MLServer == null)
                { // we need to host
                    var serv = await MasterList.StartServer("The Chase Game");
                    this.Invoke(new Action(() =>
                    {
                        handleMLReturn(serv);
                    }));
                } else
                { // update player count
                    await MasterList.SetPlayerCount(NETWORK.Connections.Count);
                    this.Invoke(new Action(() =>
                    {
                        this.Text = "Player Count updated on ML";
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.LogMsg(ex.ToString(), LogSeverity.Error);
                this.Invoke(new Action(() =>
                {
                    this.Text = $"Failed to put ML: {ex.Message}";
                }));
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            NETWORK = new NetworkHandler(this);
            NETWORK.UserJoined += NETWORK_UserJoined;
            mlTimer.Interval = 1;
            mlTimer.Start();
        }

        private void NETWORK_UserJoined(object sender, Classes.User e)
        {
            if (CurrentGame == null)
                CurrentGame = new Game();
            Common.Users[e.Id] = e;
            if (CurrentGame.P1 == null)
                CurrentGame.P1 = e;
            else if (CurrentGame.P2 == null)
                CurrentGame.P2 = e;
            else if (CurrentGame.P3 == null)
                CurrentGame.P3 = e;
            else if (CurrentGame.P4 == null)
                CurrentGame.P4 = e;
            else if (CurrentGame.Host == null)
                CurrentGame.Host = e;
            else if (CurrentGame.Chaser == null)
                CurrentGame.Chaser = e;
            else
                CurrentGame.Spectators.Add(e);
            UpdateUserList();
            NETWORK.Broadcast(new Packet(PacketId.SendGameState, CurrentGame.ToObject()));
        }

        public void UpdateUserList()
        {
            lbUsers.Items.Clear();
            foreach (var user in Common.Users.Values)
            {
                lbUsers.Items.Add($"{user.Id}: {user.Name} {CurrentGame.GetRole(user)}");
            }
        }

        private void mlTimer_Tick(object sender, EventArgs e)
        {
            if (mlTimer.Interval == 1)
                mlTimer.Interval = 29 * 1000;
            mlTimer.Interval += 1000;
            if (mlTimer.Interval > 120 * 1000)
                mlTimer.Interval = 120 * 1000;
            this.Text = $"The Chase | Updating ML... ({mlTimer.Interval / 1000})";
            RLMasterList();
        }

        // Game stuffs

        public Game CurrentGame;

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var jobj = new Newtonsoft.Json.Linq.JObject();
                jobj["reason"] = "Server close";
                NETWORK.Broadcast(new Packet(PacketId.Disconnect, jobj));
                NETWORK.Listening = false;
            } catch { }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                TheChase.Menu.SERVER = null;
                Common.Users.Clear();
                NETWORK.Connections.Clear();
                NETWORK.LISTENER.Stop();
            }
            catch { }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if(CurrentGame.Started)
            {
                btnStartGame.Enabled = false;
                return;
            }
            CurrentGame.Started = true;
            NETWORK.Broadcast(new Packet(PacketId.GameStarted, new Newtonsoft.Json.Linq.JObject()));
        }
    }
}
