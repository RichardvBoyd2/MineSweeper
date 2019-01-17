using System.Drawing;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(int size)
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
            this.Size = new Size((size * 25) + 16, (size * 25) + 39);

            //creates the grid of buttons and adds them to the form according to its position in the 2D array
            Grid grid = new Grid(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid.grid[j, i] = new Square();
                    grid.grid[j, i].Size = new Size(25, 25);
                    grid.grid[j, i].Location = new Point(j * 25, i * 25);
                    this.Controls.Add(grid.grid[j, i]);
                }
            }     

        }
        #endregion
    }
}