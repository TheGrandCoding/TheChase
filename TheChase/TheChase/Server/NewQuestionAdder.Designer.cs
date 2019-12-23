namespace TheChase.Server
{
    partial class NewQuestionAdder
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClosed = new System.Windows.Forms.TabPage();
            this.tabOpen = new System.Windows.Forms.TabPage();
            this.rtbCPrompt = new System.Windows.Forms.RichTextBox();
            this.rtbCAnswer = new System.Windows.Forms.RichTextBox();
            this.rtbCWrong1 = new System.Windows.Forms.RichTextBox();
            this.rtbCWrong2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbMbAnswer = new System.Windows.Forms.RichTextBox();
            this.rtbMbPrompt = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabClosed.SuspendLayout();
            this.tabOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClosed);
            this.tabControl1.Controls.Add(this.tabOpen);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 488);
            this.tabControl1.TabIndex = 0;
            // 
            // tabClosed
            // 
            this.tabClosed.Controls.Add(this.label4);
            this.tabClosed.Controls.Add(this.label3);
            this.tabClosed.Controls.Add(this.label2);
            this.tabClosed.Controls.Add(this.label1);
            this.tabClosed.Controls.Add(this.rtbCWrong2);
            this.tabClosed.Controls.Add(this.rtbCWrong1);
            this.tabClosed.Controls.Add(this.rtbCAnswer);
            this.tabClosed.Controls.Add(this.rtbCPrompt);
            this.tabClosed.Location = new System.Drawing.Point(4, 25);
            this.tabClosed.Name = "tabClosed";
            this.tabClosed.Padding = new System.Windows.Forms.Padding(3);
            this.tabClosed.Size = new System.Drawing.Size(806, 459);
            this.tabClosed.TabIndex = 0;
            this.tabClosed.Text = "Closed / Multiple Choice Questions";
            this.tabClosed.UseVisualStyleBackColor = true;
            // 
            // tabOpen
            // 
            this.tabOpen.Controls.Add(this.label6);
            this.tabOpen.Controls.Add(this.label7);
            this.tabOpen.Controls.Add(this.rtbMbAnswer);
            this.tabOpen.Controls.Add(this.rtbMbPrompt);
            this.tabOpen.Location = new System.Drawing.Point(4, 25);
            this.tabOpen.Name = "tabOpen";
            this.tabOpen.Padding = new System.Windows.Forms.Padding(3);
            this.tabOpen.Size = new System.Drawing.Size(806, 403);
            this.tabOpen.TabIndex = 1;
            this.tabOpen.Text = "Open / Money Builder Questions";
            this.tabOpen.UseVisualStyleBackColor = true;
            // 
            // rtbCPrompt
            // 
            this.rtbCPrompt.Location = new System.Drawing.Point(6, 30);
            this.rtbCPrompt.Name = "rtbCPrompt";
            this.rtbCPrompt.Size = new System.Drawing.Size(792, 96);
            this.rtbCPrompt.TabIndex = 0;
            this.rtbCPrompt.Text = "";
            // 
            // rtbCAnswer
            // 
            this.rtbCAnswer.BackColor = System.Drawing.Color.PaleGreen;
            this.rtbCAnswer.Location = new System.Drawing.Point(8, 145);
            this.rtbCAnswer.Name = "rtbCAnswer";
            this.rtbCAnswer.Size = new System.Drawing.Size(790, 109);
            this.rtbCAnswer.TabIndex = 1;
            this.rtbCAnswer.Text = "";
            // 
            // rtbCWrong1
            // 
            this.rtbCWrong1.BackColor = System.Drawing.Color.LightSalmon;
            this.rtbCWrong1.Location = new System.Drawing.Point(8, 277);
            this.rtbCWrong1.Name = "rtbCWrong1";
            this.rtbCWrong1.Size = new System.Drawing.Size(396, 147);
            this.rtbCWrong1.TabIndex = 2;
            this.rtbCWrong1.Text = "";
            this.rtbCWrong1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.rtbCWrong1_MouseDoubleClick);
            // 
            // rtbCWrong2
            // 
            this.rtbCWrong2.BackColor = System.Drawing.Color.LightSalmon;
            this.rtbCWrong2.Location = new System.Drawing.Point(427, 277);
            this.rtbCWrong2.Name = "rtbCWrong2";
            this.rtbCWrong2.Size = new System.Drawing.Size(371, 147);
            this.rtbCWrong2.TabIndex = 3;
            this.rtbCWrong2.Text = "";
            this.rtbCWrong2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.rtbCWrong2_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Prompt / Question";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Correct Answer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Wrong #1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wrong #2";
            // 
            // btnDone
            // 
            this.btnDone.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDone.Location = new System.Drawing.Point(0, 0);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(814, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Correct Answer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Prompt / Question";
            // 
            // rtbMbAnswer
            // 
            this.rtbMbAnswer.BackColor = System.Drawing.Color.PaleGreen;
            this.rtbMbAnswer.Location = new System.Drawing.Point(6, 138);
            this.rtbMbAnswer.Name = "rtbMbAnswer";
            this.rtbMbAnswer.Size = new System.Drawing.Size(790, 126);
            this.rtbMbAnswer.TabIndex = 8;
            this.rtbMbAnswer.Text = "";
            // 
            // rtbMbPrompt
            // 
            this.rtbMbPrompt.Location = new System.Drawing.Point(4, 23);
            this.rtbMbPrompt.Name = "rtbMbPrompt";
            this.rtbMbPrompt.Size = new System.Drawing.Size(792, 96);
            this.rtbMbPrompt.TabIndex = 7;
            this.rtbMbPrompt.Text = "";
            // 
            // NewQuestionAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 517);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.tabControl1);
            this.Name = "NewQuestionAdder";
            this.Text = "NewQuestionAdder";
            this.Load += new System.EventHandler(this.NewQuestionAdder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabClosed.ResumeLayout(false);
            this.tabClosed.PerformLayout();
            this.tabOpen.ResumeLayout(false);
            this.tabOpen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClosed;
        private System.Windows.Forms.TabPage tabOpen;
        private System.Windows.Forms.RichTextBox rtbCWrong2;
        private System.Windows.Forms.RichTextBox rtbCWrong1;
        private System.Windows.Forms.RichTextBox rtbCAnswer;
        private System.Windows.Forms.RichTextBox rtbCPrompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbMbAnswer;
        private System.Windows.Forms.RichTextBox rtbMbPrompt;
    }
}