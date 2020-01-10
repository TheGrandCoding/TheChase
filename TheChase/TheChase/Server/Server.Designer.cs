namespace TheChase.Server
{
    partial class Server
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.lobbyPanel = new System.Windows.Forms.Panel();
            this.btnAddNewQs = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.mlTimer = new System.Windows.Forms.Timer(this.components);
            this.questionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.lobbyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lobbyPanel);
            this.splitContainer1.Size = new System.Drawing.Size(600, 366);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbUsers
            // 
            this.lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(0, 0);
            this.lbUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(300, 366);
            this.lbUsers.TabIndex = 0;
            // 
            // lobbyPanel
            // 
            this.lobbyPanel.Controls.Add(this.btnAddNewQs);
            this.lobbyPanel.Controls.Add(this.btnStartGame);
            this.lobbyPanel.Location = new System.Drawing.Point(2, 10);
            this.lobbyPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lobbyPanel.Name = "lobbyPanel";
            this.lobbyPanel.Size = new System.Drawing.Size(286, 118);
            this.lobbyPanel.TabIndex = 0;
            // 
            // btnAddNewQs
            // 
            this.btnAddNewQs.Location = new System.Drawing.Point(167, 2);
            this.btnAddNewQs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddNewQs.Name = "btnAddNewQs";
            this.btnAddNewQs.Size = new System.Drawing.Size(116, 70);
            this.btnAddNewQs.TabIndex = 1;
            this.btnAddNewQs.Text = "Add New Questions";
            this.btnAddNewQs.UseVisualStyleBackColor = true;
            this.btnAddNewQs.Click += new System.EventHandler(this.btnAddNewQs_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(2, 2);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(116, 70);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // mlTimer
            // 
            this.mlTimer.Tick += new System.EventHandler(this.mlTimer_Tick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.Load += new System.EventHandler(this.Server_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.lobbyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Timer mlTimer;
        private System.Windows.Forms.Panel lobbyPanel;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnAddNewQs;
        private System.Windows.Forms.Timer questionTimer;
    }
}