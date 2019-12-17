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

namespace TheChase.Client
{
    public partial class MainClient : Form
    {
        public MainClient()
        {
            InitializeComponent();
        }

        Thread rlMLThread = null;

        void handleMLReturn(Classes.MasterlistServer[] servers)
        {
            rlMLThread = null;
            dgvServers.Rows.Clear();
            foreach (var srv in servers.OrderBy(x => x.CurrentPlayers))
            {
                string[] row = new string[] { srv.Name, srv.InternalIP, srv.CurrentPlayers.ToString(), srv.ExternalIP };
                dgvServers.Rows.Add(row);
            }
            this.Text = $"Fetched ML: {servers.Length} servers";
        }

        async void RLMasterList()
        {
            if(!this.InvokeRequired)
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
                var servers = await MasterList.GetServers();
                this.Invoke(new Action(() =>
                {
                    handleMLReturn(servers);
                }));
            }
            catch (Exception ex)
            {
                Logger.LogMsg(ex.ToString(), LogSeverity.Error);
                this.Invoke(new Action(() =>
                {
                    this.Text = $"Failed to get ML: {ex.Message}";
                }));
            }
        }

        private void MainClient_Load(object sender, EventArgs e)
        {
            mlTimer.Interval = 1;
            mlTimer.Start();
        }

        private void mlTimer_Tick(object sender, EventArgs e)
        {
            if(mlTimer.Interval == 1)
                mlTimer.Interval = 29 * 1000;
            mlTimer.Interval += 1000;
            if (mlTimer.Interval > 120 * 1000)
                mlTimer.Interval = 120 * 1000;
            this.Text = $"The Chase | Fetching Servers... ({mlTimer.Interval / 1000})";
            RLMasterList();
        }

        private void MainClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            TheChase.Menu.CLIENT = null;
            TheChase.Menu.INSTANCE.Show();
        }
    }
}
