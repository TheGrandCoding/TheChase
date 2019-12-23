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
        public bool MoneyBuilderStarted = false;
        public bool QuestionsStarted = false;
        public bool FinalChaseStarted = false;
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

        Color getColor(Control lbl)
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

        void setupControlUser(Control control, User u, string text = null, bool doBackElseFront = true)
        {
            if (text == null)
                text = u.Name;
            control.Text = text;
            if(doBackElseFront)
            {
                control.BackColor = u.Id == SelfUser.Id ? Color.Yellow : getColor(control);
                control.ForeColor = Color.Black;
            } else
            {
                control.ForeColor = u.Id == SelfUser.Id ? Color.Yellow : getColor(control);
                control.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        void gameReflectControls(Game e, Control P1, Control P2, Control P3, Control P4, Control Host, Control Chaser)
        {
            P1.Tag = e.P1;
            P2.Tag = e.P2;
            P3.Tag = e.P3;
            P4.Tag = e.P4;
            Host.Tag = e.Host;
            Chaser.Tag = e.Chaser;
            foreach (var lbl in new Control[] { P1, P2, P2, P3, P4, Host, Chaser })
            {
                if (lbl.Tag == null)
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
                }
                else if (lbl.Tag is User usr)
                {
                    setupControlUser(lbl, usr);
                }
            }
            lbSpectators.Items.Clear();
            lbSpectators.Items.Add("Spectators:");
            foreach (var spectator in e.Spectators)
            {
                if (spectator == SelfUser)
                {
                    lbSpectators.Items.Add($"[{spectator.Name}]");
                }
                else
                {
                    lbSpectators.Items.Add(spectator.Name);
                }
            }
        }

        private void Client_GameUpdate(object sender, Classes.Game e)
        {
            if(e.Stage == GameStage.Lobby)
            {
                gameReflectControls(e, lblP1, lblP2, lblP3, lblP4, lblHost, lblChaser);
                TabControlPage = 1;
            } else if (e.Stage == GameStage.MoneyBuilders)
            {
                TabControlPage = 2;
                gameReflectControls(e, btnMBP1, btnMBP2, btnMBP3, btnMBP4, btnMBHost, btnMBChaser);
                setupControlUser(lblMGPlaying, e.WaitingOn, $"Playing: {e.WaitingOn.Name}", false);
                if(e.WaitingOn.Id == SelfUser.Id)
                {
                    Client.Send(new Packet(PacketId.ReadyMB, new Newtonsoft.Json.Linq.JObject()).ToString());
                }
                gbMBResponses.Visible = e.WaitingOn.Id == SelfUser.Id;
                txtMGText.Text = "";
            }
            fixSplittersHalf();
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

        void fixSplittersHalf()
        {
            this.ForAllControls(x =>
            {
                if (x is SplitContainer split)
                {
                    split.SplitterDistance = (int)(split.Width / 2);
                    split.IsSplitterFixed = true;
                }
            });
        }

        private void MainClient_Load(object sender, EventArgs e)
        {
            mlTimer.Interval = 1;
            mlTimer.Start();
            TabControlPage = 0;
            fixSplittersHalf();
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
