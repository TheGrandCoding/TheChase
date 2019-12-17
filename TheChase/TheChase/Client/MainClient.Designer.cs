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
            this.mlTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).BeginInit();
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
            this.Column4});
            this.dgvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServers.Location = new System.Drawing.Point(0, 0);
            this.dgvServers.Name = "dgvServers";
            this.dgvServers.ReadOnly = true;
            this.dgvServers.RowHeadersVisible = false;
            this.dgvServers.RowHeadersWidth = 51;
            this.dgvServers.RowTemplate.Height = 24;
            this.dgvServers.Size = new System.Drawing.Size(583, 339);
            this.dgvServers.TabIndex = 0;
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
            // mlTimer
            // 
            this.mlTimer.Interval = 5000;
            this.mlTimer.Tick += new System.EventHandler(this.mlTimer_Tick);
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 339);
            this.Controls.Add(this.dgvServers);
            this.Name = "MainClient";
            this.Text = "MainClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainClient_FormClosed);
            this.Load += new System.EventHandler(this.MainClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Timer mlTimer;
    }
}