using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheChase.Classes;

namespace TheChase.Client
{
    public partial class MainClient : Form
    {
        private int _tab = 0;
        public int TabControlPage {  get
            {
                return _tab;
            } set
            {
                _tab = value;
                this.Invoke(new Action(() =>
                {
                    tabControl1.SelectedIndex = value;
                }));
            }
        }
        public Classes.User SelfUser;
        public MainClient()
        {
            InitializeComponent();
            Client = new ClientConnection(this, Environment.UserName, Disconnect);
            Client.SelfIdentity += Client_SelfIdentity;
            Client.UserJoined += Client_UserJoined;
            Client.UserDisconnect += Client_UserDisconnect;
            Client.GameUpdate += Client_GameUpdate;
        }

        Color getColor(Label lbl)
        {
            var last = lbl.Name[lbl.Name.Length - 1];
            if (last == 't')
            {
                return Color.Silver;
            }
            else if (last == 'r')
            {
                return Color.IndianRed;
            }
            return Color.LightBlue;
        }

        private void Client_GameUpdate(object sender, Classes.Game e)
        {
            lblP1.Tag = e.P1;
            lblP2.Tag = e.P2;
            lblP3.Tag = e.P3;
            lblP4.Tag = e.P4;
            lblHost.Tag = e.Host;
            lblChaser.Tag = e.Chaser;
            foreach(var lbl in new Label[] { lblP1, lblP2, lblP2, lblP3, lblP4, lblHost, lblChaser})
            {
                if(lbl.Tag == null)
                {
                    var last = lbl.Name[lbl.Name.Length - 1];
                    lbl.BackColor = getColor(lbl);
                    if (last == 't')
                    {
                        lbl.Text = "Host";
                    }
                    else if (last == 'r')
                    {
                        lbl.Text = "Chaser";
                    }
                    else
                    {
                        lbl.Text = "Player #" + last.ToString();
                    }
                } else if(lbl.Tag is User usr)
                {
                    lbl.Text = usr.Name;
                    lbl.BackColor = usr.Id == SelfUser.Id ? Color.Yellow : getColor(lbl);
                    lbl.ForeColor = Color.Black;
                }
            }
            lbSpectators.Items.Clear();
            lbSpectators.Items.Add("Spectators:");
            foreach(var spectator in e.Spectators)
            {
                if(spectator == SelfUser)
                {
                    lbSpectators.Items.Add($"[{spectator.Name}]");
                } else
                {
                    lbSpectators.Items.Add(spectator.Name);
                }
            }
        }

        private void Client_UserDisconnect(object sender, Classes.User e)
        {
            Common.Users.Remove(e.Id);
        }

        private void Client_UserJoined(object sender, Classes.User e)
        {
            Common.Users[e.Id] = e;
        }

        private void Client_SelfIdentity(object sender, Classes.User e)
        {
            SelfUser = e;
            Client_UserJoined(this, e);
            mlTimer.Stop();
            TabControlPage = 1;
        }

        public ClientConnection Client { get; set; }

        Task Connect(IPAddress addr)
        {
            return Client.Connect(addr);
        }

        async Task Disconnect(Classes.Connection conn, Exception ex)
        {
            Logger.LogMsg($"C/D-C: {ex}", LogSeverity.Error);
            setText($"Disconnected: {ex.Message}");
            TabControlPage = 0;
            SelfUser = null;
            this.Close();
        }

        Thread rlMLThread = null;

        void handleMLReturn(Classes.MasterlistServer[] servers)
        {
            rlMLThread = null;
            dgvServers.Rows.Clear();
            foreach (var srv in servers.OrderBy(x => x.CurrentPlayers))
            {
                string[] row = new string[] { srv.Name, srv.InternalIP, srv.CurrentPlayers.ToString(), srv.ExternalIP, "Join" };
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
            TabControlPage = 0;
            foreach(var split in new SplitContainer[] { splitContainer1, splitContainer2, splitContainer3, splitContainer4 })
            {
                split.SplitterDistance = (int)(split.Width / 2);
            }
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
            Client.Listening = false;
            Client.Client.Close();
            TheChase.Menu.CLIENT = null;
            TheChase.Menu.INSTANCE.Show();
        }

        Thread connThread;

        void setText(string text)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    setText(text);
                }));
                return;
            }
            this.Text = text;
        }

        void doConnectStuffOnThread(IPAddress intAddr, IPAddress extAddr, IPAddress thisAddr)
        {
            if(extAddr.Equals(thisAddr))
            { // we are in same network, so connect via internal
                var task = Connect(intAddr);
                try
                {
                    task.Wait(1000 * 10);
                    if(!Client.Client.Connected)
                    {
                        setText($"Failed to connect internally");
                        Thread.Sleep(1500);
                        setText($"Attempting external connect");
                    } else
                    {
                        Client.Listen();
                        setText("Connected!");
                        Client.Send(Environment.UserName);
                        return;
                    }
                } catch (AggregateException ex)
                {
                    string errrs = string.Join(" // ", ex.InnerExceptions.Select(x => x.Message));
                    Logger.LogMsg($"Aggregate: {errrs}", LogSeverity.Error);
                    setText($"ERR: {errrs}");
                    return;
                }
                catch (Exception ex)
                {
                    Logger.LogMsg(ex.ToString(), LogSeverity.Error);
                    setText($"ERR: {ex.Message}");
                    return;
                }
            }
            // either different network, or failed internal connection
            try
            {
                var second = Connect(extAddr);
                second.Wait(1000 * 10);
                if (Client.Client.Connected)
                {
                    setText("Connected");
                    Client.Listen();
                    Client.Send(Environment.UserName);
                }
                else
                {
                    setText("Failed to connect");
                }
            } catch (Exception ex)
            {
                Logger.LogMsg(ex.ToString(), LogSeverity.Error);
                setText($"ERR: {ex.Message}");
                return;
            }
        }

        string ExternalIP = null;

        async void fetchOwnExternalIP(string name, IPAddress intAddr, IPAddress extAddr)
        {
            if(string.IsNullOrWhiteSpace(ExternalIP))
            {
                setText("Fetching our IP");
                ExternalIP = await MasterList.GetExternalIP();
                setText("Fetched own IP");
                Thread.Sleep(500);
            }
            setText($"Connecting to {name}");
            connThread = new Thread(() => doConnectStuffOnThread(intAddr, extAddr, IPAddress.Parse(ExternalIP)));
            connThread.Start();
        }

        private void dgvServers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var row = dgvServers.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if(cell is DataGridViewButtonCell btn)
            {
                var inti = row.Cells[1].Value as string;
                var extI = row.Cells[3].Value as string;
                if(IPAddress.TryParse(inti, out var intAddr) && IPAddress.TryParse(extI, out var extAddr))
                {
                    var any = new Thread(() => fetchOwnExternalIP(row.Cells[0].Value as string, intAddr, extAddr));
                    any.Start();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = TabControlPage;
        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.Text = $"{e.SplitX} {e.SplitY} | {splitContainer4.SplitterDistance} {splitContainer4.Width}";
        }

        void requestRole(char type)
        {
            var jobj = new Newtonsoft.Json.Linq.JObject();
            jobj["r"] = type;
            Client.Send(new Packet(PacketId.RequestRole, jobj).ToString());
        }

        private void lblHost_DoubleClick(object sender, EventArgs e)
        {
            requestRole('H');
        }

        private void lblChaser_Click(object sender, EventArgs e)
        {
            requestRole('C');
        }

        private void lblPlayer_DoubleClick(object sender, EventArgs e)
        {
            requestRole('P');
        }

        private void lbSpectators_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            requestRole('S');
        }
    }
}
