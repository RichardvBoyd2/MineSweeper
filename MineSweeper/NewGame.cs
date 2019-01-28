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
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }      

        //creates a game board according to the difficulty selected
        private void button1_Click(object sender, EventArgs e)
        {
            int size = 0;
            if (radioButton1.Checked)
            {
                size = 10;
            }
            if (radioButton2.Checked)
            {
                size = 15;
            }
            if (radioButton3.Checked)
            {
                size = 20;
            }
            //hides this form and opens the game, also sets this form to close when the game form is closed
            this.Hide();
            Main main = new Main(size);
            main.FormClosed += (s, args) => this.Show();
            main.Show();            
        }
    }
}
