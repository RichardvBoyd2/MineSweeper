using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    //creates a 2D array of Squares
    class Grid
    {
        public Square[,] grid;

        public Grid (int size)
        {
            grid = new Square[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[j, i] = new Square();
                    grid[j, i].Text = "";
                    grid[j, i].Size = new Size(25, 25);
                }
            }
        }
    }
}