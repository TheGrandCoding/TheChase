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
            this.Text = $"Server Hosted on ML";
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
            NETWORK = new NetworkHandler();
            NETWORK.UserJoined += NETWORK_UserJoined;
            mlTimer.Interval = 1;
            mlTimer.Start();
        }

        private void NETWORK_UserJoined(object sender, Classes.User e)
        {
            lbUsers.Items.Clear();
            foreach(var user in Common.Users.Values)
            {
                lbUsers.Items.Add($"{user.Id}: {user.Name}");
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
    }
}
