namespace TheChase.Client
{
    partial class MainClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvServers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mlTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConnect = new System.Windows.Forms.TabPage();
            this.tabLobby = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblChaser = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblP4 = new System.Windows.Forms.Label();
            this.lblP3 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.lbSpectators = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabConnect.SuspendLayout();
            this.tabLobby.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvServers
            // 
            this.dgvServers.AllowUserToAddRows = false;
            this.dgvServers.AllowUserToDeleteRows = false;
            this.dgvServers.AllowUserToResizeColumns = false;
            this.dgvServers.AllowUserToResizeRows = false;
            this.dgvServers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServers.Location = new System.Drawing.Point(3, 3);
            this.dgvServers.Name = "dgvServers";
            this.dgvServers.ReadOnly = true;
            this.dgvServers.RowHeadersVisible = false;
            this.dgvServers.RowHeadersWidth = 51;
            this.dgvServers.RowTemplate.Height = 24;
            this.dgvServers.Size = new System.Drawing.Size(1116, 464);
            this.dgvServers.TabIndex = 0;
            this.dgvServers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServers_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Server Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IP";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Players";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ExtIp";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Connect";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // mlTimer
            // 
            this.mlTimer.Interval = 5000;
            this.mlTimer.Tick += new System.EventHandler(this.mlTimer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConnect);
            this.tabControl1.Controls.Add(this.tabLobby);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1130, 499);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabConnect
            // 
            this.tabConnect.Controls.Add(this.dgvServers);
            this.tabConnect.Location = new System.Drawing.Point(4, 25);
            this.tabConnect.Name = "tabConnect";
            this.tabConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnect.Size = new System.Drawing.Size(1122, 470);
            this.tabConnect.TabIndex = 0;
            this.tabConnect.Text = "Server List";
            this.tabConnect.UseVisualStyleBackColor = true;
            // 
            // tabLobby
            // 
            this.tabLobby.Controls.Add(this.splitContainer4);
            this.tabLobby.Controls.Add(this.splitContainer1);
            this.tabLobby.Location = new System.Drawing.Point(4, 25);
            this.tabLobby.Name = "tabLobby";
            this.tabLobby.Padding = new System.Windows.Forms.Padding(3);
            this.tabLobby.Size = new System.Drawing.Size(1122, 470);
            this.tabLobby.TabIndex = 1;
            this.tabLobby.Text = "Lobby";
            this.tabLobby.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer4.Location = new System.Drawing.Point(3, 291);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lbSpectators);
            this.splitContainer4.Panel1.Controls.Add(this.lblHost);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.lblChaser);
            this.splitContainer4.Size = new System.Drawing.Size(1116, 176);
            this.splitContainer4.SplitterDistance = 558;
            this.splitContainer4.TabIndex = 7;
            this.splitContainer4.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer4_SplitterMoved);
            // 
            // lblHost
            // 
            this.lblHost.BackColor = System.Drawing.Color.Silver;
            this.lblHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(0, 0);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(558, 57);
            this.lblHost.TabIndex = 4;
            this.lblHost.Text = "Host";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHost.DoubleClick += new System.EventHandler(this.lblHost_DoubleClick);
            // 
            // lblChaser
            // 
            this.lblChaser.BackColor = System.Drawing.Color.IndianRed;
            this.lblChaser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChaser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaser.Location = new System.Drawing.Point(0, 0);
            this.lblChaser.Name = "lblChaser";
            this.lblChaser.Size = new System.Drawing.Size(554, 57);
            this.lblChaser.TabIndex = 5;
            this.lblChaser.Text = "Chaser";
            this.lblChaser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChaser.Click += new System.EventHandler(this.lblChaser_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1116, 133);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblP4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblP3);
            this.splitContainer2.Size = new System.Drawing.Size(558, 133);
            this.splitContainer2.SplitterDistance = 279;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblP4
            // 
            this.lblP4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblP4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP4.Location = new System.Drawing.Point(0, 0);
            this.lblP4.Name = "lblP4";
            this.lblP4.Size = new System.Drawing.Size(279, 133);
            this.lblP4.TabIndex = 3;
            this.lblP4.Text = "Player Four";
            this.lblP4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblP4.DoubleClick += new System.EventHandler(this.lblPlayer_DoubleClick);
            // 
            // lblP3
            // 
            this.lblP3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP3.Location = new System.Drawing.Point(0, 0);
            this.lblP3.Name = "lblP3";
            this.lblP3.Size = new System.Drawing.Size(275, 133);
            this.lblP3.TabIndex = 2;
            this.lblP3.Text = "Player Three";
            this.lblP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblP3.DoubleClick += new System.EventHandler(this.lblPlayer_DoubleClick);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblP2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lblP1);
            this.splitContainer3.Size = new System.Drawing.Size(554, 133);
            this.splitContainer3.SplitterDistance = 279;
            this.splitContainer3.TabIndex = 0;
            // 
            // lblP2
            // 
            this.lblP2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2.Location = new System.Drawing.Point(0, 0);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(279, 133);
            this.lblP2.TabIndex = 1;
            this.lblP2.Text = "Player Two";
            this.lblP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblP2.DoubleClick += new System.EventHandler(this.lblPlayer_DoubleClick);
            // 
            // lblP1
            // 
            this.lblP1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1.Location = new System.Drawing.Point(0, 0);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(271, 133);
            this.lblP1.TabIndex = 0;
            this.lblP1.Text = "Player One";
            this.lblP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblP1.DoubleClick += new System.EventHandler(this.lblPlayer_DoubleClick);
            // 
            // lbSpectators
            // 
            this.lbSpectators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSpectators.FormattingEnabled = true;
            this.lbSpectators.ItemHeight = 16;
            this.lbSpectators.Items.AddRange(new object[] {
            "Spectators:"});
            this.lbSpectators.Location = new System.Drawing.Point(0, 57);
            this.lbSpectators.Name = "lbSpectators";
            this.lbSpectators.Size = new System.Drawing.Size(558, 119);
            this.lbSpectators.TabIndex = 5;
            this.lbSpectators.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSpectators_MouseDoubleClick);
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 499);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainClient";
            this.Text = "MainClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainClient_FormClosed);
            this.Load += new System.EventHandler(this.MainClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabConnect.ResumeLayout(false);
            this.tabLobby.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Timer mlTimer;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConnect;
        private System.Windows.Forms.TabPage tabLobby;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblP4;
        private System.Windows.Forms.Label lblP3;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblChaser;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox lbSpectators;
    }
}