using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{    
    class Grid
    {
        public Square[,] grid;

        //creates a 2D array of Squares, and calls Activate and NeighborCount
        public Grid (int size)
        {
            grid = new Square[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[j, i] = new Square();
                    grid[j, i].col = j;
                    grid[j, i].row = i;
                }
            }
            Activate(size);
            NeighborCount(size);
        }

        //randomly activates a random number (around 15%-20%) of Squares        
        public void Activate(int size)
        {
            Random random = new Random();
            int actives = random.Next((((size * size) * 15) / 100), (((size * size) * 20) / 100));
            int x, y;
            for (int i = 0; i < actives; i++)
            {
                x = random.Next(size);
                y = random.Next(size);

                if (grid[x, y].live == true)
                {
                    i--;
                }
                else
                {
                    grid[x, y].live = true;
                }
            }
        }

        //counts the amount of active neighbors of each cell
        public void NeighborCount(int size)
        {
            int count;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    count = 0;
                    //sets the neighbor count to 9 if the cell is active
                    if (grid[j, i].live == true)
                    {
                        grid[j, i].liveneighbors = 9;
                    }
                    //counts cells, within value checks to prevent out of bounds exceptions
                    else
                    {
                        if (j + 1 < size)
                        {
                            if (grid[j + 1, i].live == true)
                            {
                                count++;
                            }
                            if (i + 1 < size)
                            {
                                if (grid[j + 1, i + 1].live == true)
                                {
                                    count++;
                                }
                            }
                            if (i > 0)
                            {
                                if (grid[j + 1, i - 1].live == true)
                                {
                                    count++;
                                }
                            }
                        }
                        if (i + 1 < size)
                        {
                            if (grid[j, i + 1].live == true)
                            {
                                count++;
                            }
                        }
                        if (j > 0)
                        {
                            if (grid[j - 1, i].live == true)
                            {
                                count++;
                            }
                            if (i + 1 < size)
                            {
                                if (grid[j - 1, i + 1].live == true)
                                {
                                    count++;
                                }
                            }
                            if (i > 0)
                            {
                                if (grid[j - 1, i - 1].live == true)
                                {
                                    count++;
                                }
                            }
                        }
                        if (i > 0)
                        {
                            if (grid[j, i - 1].live == true)
                            {
                                count++;
                            }
                        }
                        grid[j, i].liveneighbors = count;
                    }
                }
            }
        }
    }
}