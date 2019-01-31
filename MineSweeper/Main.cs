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
        string time, level;
        public Main(int size)
        {
            if (size == 10)
            {
                level = "Easy";
            }
            if (size == 15)
            {
                level = "Normal";
            }
            if (size == 20)
            {
                level = "Hard";
            }
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
                    if (minesweeperGame.win == true)
                    {
                        this.Enabled = false;
                        int totaltime = sec + (min * 60) + (hour * 3600);
                        EnterName enterName = new EnterName(totaltime, level);
                        enterName.FormClosed += (s, args) => this.Close();
                        enterName.Show();
                    }
                    else
                    {
                        this.Enabled = false;
                        HighScores highScores = new HighScores(level);
                        highScores.FormClosed += (s, args) => this.Close();
                        highScores.Show();
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