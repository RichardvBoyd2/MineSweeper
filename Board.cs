using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227MilestoneProject
{
    abstract class Board
    {
        public int size;
        public Cell[,] game;
        Random Random = new Random();

        //creates square grid with entered parameter and creates cells for each space
        public Board(int size)
        {
            this.size = size;
            game = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    game[j, i] = new Cell();
                }
            }
        }

        //randomly activates a random number (around 15%-20%) of cells
        public void Activate()
        {
            int actives = Random.Next((((size * size) * 15) / 100), (((size * size) * 20) / 100));
            int x, y;
            for (int i = 0; i < actives; i++)
            {
                x = Random.Next(size);
                y = Random.Next(size);

                if (game[x, y].live == true)
                {
                    i--;
                }
                else
                {
                    game[x, y].live = true;
                }
            }
        }

        //counts the amount of active neighbors of each cell
        public void NeighborCount()
        {
            int count;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    count = 0;
                    //sets the neighbor count to 9 if the cell is active
                    if (game[j, i].live == true)
                    {
                        game[j, i].liveneighbors = 9;
                    }
                    //counts cells, within value checks to prevent out of bounds exceptions
                    else
                    {
                        if (j + 1 < size)
                        {
                            if (game[j + 1, i].live == true)
                            {
                                count++;
                            }
                            if (i + 1 < size)
                            {
                                if (game[j + 1, i + 1].live == true)
                                {
                                    count++;
                                }
                            }
                            if (i > 0)
                            {
                                if (game[j + 1, i - 1].live == true)
                                {
                                    count++;
                                }
                            }
                        }
                        if (i + 1 < size)
                        {
                            if (game[j, i + 1].live == true)
                            {
                                count++;
                            }
                        }
                        if (j > 0)
                        {
                            if (game[j - 1, i].live == true)
                            {
                                count++;
                            }
                            if (i + 1 < size)
                            {
                                if (game[j - 1, i + 1].live == true)
                                {
                                    count++;
                                }
                            }
                            if (i > 0)
                            {
                                if (game[j - 1, i - 1].live == true)
                                {
                                    count++;
                                }
                            }
                        }
                        if (i > 0)
                        {
                            if (game[j, i - 1].live == true)
                            {
                                count++;
                            }
                        }
                        game[j, i].liveneighbors = count;
                    }
                }
            }
        }

        //displays board to the console
        public virtual void Display()
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (game[j, i].live)
                    {
                        Console.Write(" *");
                    }
                    else if (game[j, i].liveneighbors == 0)
                    {
                        Console.Write(" ~");
                    }
                    else
                    {
                        Console.Write(" " + game[j, i].liveneighbors);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
