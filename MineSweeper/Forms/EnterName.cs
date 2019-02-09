using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class EnterName : Form
    {
        int totaltime;
        string difficulty, initials;
        public EnterName(int time, string level)
        {
            totaltime = time;
            difficulty = level;
            InitializeComponent(time);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 3)
            {
                MessageBox.Show("Enter 3 characters or less");
            }
            else
            {
                initials = textBox1.Text;
                HighScores highScores = new HighScores(initials, difficulty, totaltime);
                highScores.FormClosed += (s, args) => this.Close();
                this.Hide();
                highScores.Show();
            }
        }
    }
}
