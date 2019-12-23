using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheChase.Classes;

namespace TheChase.Server
{
    public partial class NewQuestionAdder : Form
    {
        public NewQuestionAdder()
        {
            InitializeComponent();
        }

        static int index = 0;

        public Question GetQuestion()
        {
            index = tabControl1.SelectedIndex;
            if(tabControl1.SelectedIndex == 0)
            { // closed
                // null checks
                bool invalid = false;
                foreach(var item in new RichTextBox[] { rtbCAnswer, rtbCPrompt, rtbCWrong1, rtbCWrong2})
                {
                    if(string.IsNullOrWhiteSpace(item.Text))
                    {
                        item.BackColor = Color.Red;
                        invalid = true;
                    } else
                    {
                        item.BackColor = (Color)item.Tag;
                    }
                }
                if(invalid)
                {
                    MessageBox.Show("You have empty text boxes", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                var q = new Question();
                q.Prompt = rtbCPrompt.Text;
                q.Answers = (new RichTextBox[] { rtbCAnswer, rtbCWrong1, rtbCWrong2}).Select(x => x.Text).ToArray();
                q.CorrectAnswer = 0;
                return q;
            } else
            {
                bool invalid = false;
                foreach (var item in new RichTextBox[] { rtbMbAnswer, rtbMbPrompt })
                {
                    if (string.IsNullOrWhiteSpace(item.Text))
                    {
                        item.BackColor = Color.Red;
                        invalid = true;
                    }
                    else
                    {
                        item.BackColor = (Color)item.Tag;
                    }
                }
                if (invalid)
                {
                    MessageBox.Show("You have empty text boxes", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                var q = new MoneyBuilderQ();
                q.Prompt = rtbMbPrompt.Text;
                q.Answers = new string[] { rtbMbAnswer.Text };
                q.CorrectAnswer = 0;
                return q;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var q = GetQuestion();
            if(q != null)
            {
                this.Close();
            }
        }

        private void NewQuestionAdder_Load(object sender, EventArgs e)
        {
            this.ForAllControls(x =>
            {
                if (x is RichTextBox rtb)
                {
                    x.Tag = x.BackColor;
                }
            });
            this.tabControl1.SelectedIndex = index;
        }

        void swapAnswer(RichTextBox rtb)
        {
            string old = rtbCAnswer.Text;
            rtbCAnswer.Text = rtb.Text;
            rtb.Text = old;
        }

        private void rtbCWrong1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            swapAnswer(sender as RichTextBox);
        }

        private void rtbCWrong2_MouseDoubleClick(object sender, EventArgs e)
        {
            swapAnswer(sender as RichTextBox);
        }
    }
}
