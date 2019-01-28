using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    class Square : Button
    {        
        //makes the default text blank
        public override string Text { get => ""; }

        //properties for game logic to use
        public int row { get; set; } = -1;
        public int col { get; set; } = -1;
        public bool visited { get; set; } = false;
        public bool live { get; set; } = false;
        public bool lose { get; set; } = false;
        public bool flagged { get; set; } = false;
        public int liveneighbors { get; set; } = 0;        

        //changes the image of the square based on it's properties
        public void RefreshSquare()
        {
            if (this.visited == false)
            {
                if (this.flagged == true)
                {
                    this.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/flag.png"));
                    this.ImageResize();
                }
                else
                {
                    this.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/unexplored.png"));
                    this.ImageResize();
                }
            }
            else
            {
                if (this.lose)
                {
                    this.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/lose.png"));
                    this.ImageResize();
                }
                else if (this.live && this.flagged)
                {
                    this.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/flag.png"));
                    this.ImageResize();
                }
                else if (this.live)
                {
                    this.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/mine2.ico"));
                    this.ImageResize();
                }
                else
                {
                    this.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Icons/" + this.liveneighbors + ".png"));
                    this.ImageResize();
                }
            }
        }

        //resizes image to match the size of the Square
        public void ImageResize()
        {
            var pic = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
            this.BackgroundImage = pic;
        }

    }
}