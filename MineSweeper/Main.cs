using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Main : Form
    {
        MinesweeperGame minesweeperGame;
        int sec, min, hour;
        String time;
        public Main(int size)
        {
            minesweeperGame = new MinesweeperGame(size);
            InitializeComponent(size, minesweeperGame);
        }        

        //method that fires when a cell is clicked
        private void CellClick(object sender, MouseEventArgs e)
        {
            Square clicked = sender as Square;
            //changes the action taken depending on left click or right click
            if (e.Button == MouseButtons.Left)
            {
                minesweeperGame.CellVisit(clicked.col, clicked.row);
                //ends the game, displays the time and the appropriate response if the player won or lost
                if (minesweeperGame.gameover == true)
                {
                    time = "Time: " + hours.Text + minutes.Text + seconds.Text;
                    DialogResult result = MessageBox.Show(time + "\n" + minesweeperGame.message, minesweeperGame.caption);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                clicked.flagged = true;
                minesweeperGame.RefreshGame();
            }            
        }

        //tick method that updates time every second
        private void timer_Tick(object sender, EventArgs e)
        {
            if (minesweeperGame.gameover == false)
            {
                sec++;
                if (sec >= 60)
                {
                    min++;
                    sec = 0;
                    if (min >= 60)
                    {
                        hour++;
                        min = 0;
                    }
                }
                DrawTime();
            }
        }

        //updates the displayed time on the game form when called
        private void DrawTime()
        {
            seconds.Text = String.Format("{0:00}", sec);
            minutes.Text = String.Format("{0:00}" + ":", min);
            hours.Text = String.Format("{0:00}" + ":", hour);
        }
    }
}