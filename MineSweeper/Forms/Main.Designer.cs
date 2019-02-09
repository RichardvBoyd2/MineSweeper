using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MineSweeper.Properties;

namespace MineSweeper
{
    partial class Main
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
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(int size, MinesweeperGame minesweeperGame)
        {
            this.SuspendLayout();
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "MineSweeper";
            this.ResumeLayout(false);
            //centers the game, prevents resizing, and makes it the appropriate size for how many buttons there are going to be
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new Size((size * 50) + 16, (size * 50) + 80);
            //
            // timer
            //
            this.timer = new Timer();
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(this.timer_Tick);
            //
            // seconds label
            //
            this.seconds = new Label();
            this.seconds.AutoSize = true;
            this.seconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seconds.Location = new System.Drawing.Point(110, 0);
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(30, 21);
            this.seconds.Text = "00";
            this.Controls.Add(this.seconds);
            //
            // minutes label
            //
            this.minutes = new Label();
            this.minutes.AutoSize = true;
            this.minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutes.Location = new System.Drawing.Point(55, 0);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(30, 21);            
            this.minutes.Text = "00:";
            this.Controls.Add(this.minutes);
            //
            // hours label
            //
            this.hours = new Label();
            this.hours.AutoSize = true;
            this.hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hours.Location = new System.Drawing.Point(0, 0);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(30, 21);
            this.hours.Text = "00:";
            this.Controls.Add(this.hours);           

            //creates the grid of buttons and adds them to the form according to its position in the 2D array            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {                    
                    minesweeperGame.grid[j, i].Size = new Size(50, 50);
                    minesweeperGame.grid[j, i].BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/unexplored.png"));
                    minesweeperGame.grid[j, i].ImageResize();
                    minesweeperGame.grid[j, i].Location = new Point(j * 50, (i * 50) + 41);
                    this.Controls.Add(minesweeperGame.grid[j, i]);
                    this.minesweeperGame.grid[j, i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.CellClick);
                }
            }
        }
        private Timer timer;
        private Label seconds;
        private Label minutes;
        private Label hours;        
    }
}