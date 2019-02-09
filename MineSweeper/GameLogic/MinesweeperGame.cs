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
    class MinesweeperGame : Grid, IPlayable
    {
        int size = 0;
        public bool gameover = false, win = false;
        public string message, caption;

        public MinesweeperGame(int size) : base(size)
        {
            this.size = size;
        }

        //not used, not sure if needed for assignment
        //previous game logic required use of interface that included this method, no longer needed for current build
        public void PlayGame()
        {
        }

        //main method that fires when a cell is left clicked
        public void CellVisit(int x, int y)
        {
            grid[x, y].visited = true;
            if (grid[x, y].live == true)
            {
                gameover = true;
                grid[x, y].lose = true;
                message = "Sorry! Try again!";
                caption = "You lose!";                
            }
            else if (grid[x,y].liveneighbors == 0)
            {
                RecursiveTest(x, y);
            }            
            RefreshGame();
        }

        //parses through all Squares and fires RefreshSquare for each Square
        public void RefreshGame()
        {
            if (Win(grid))
            {                
                gameover = true;
                win = true;
            }
            if (gameover == true)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        grid[j, i].visited = true;
                    }
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[j, i].RefreshSquare();                    
                }
            }            
        }

        //test the whole board to see if the game has been won yet
        //TODO maybe change argument
        public bool Win(Square[,] test)
        {
            bool wincondition = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (test[j, i].live == false && test[j, i].visited == false)
                    {
                        wincondition = false;
                    }
                }
            }
            return wincondition;
        }

        //Recursive method that reveals blocks of Squares with no live neighbors when one is visited
        public void RecursiveTest(int x, int y)
        {
            if (x + 1 < size)
            {
                if (grid[x + 1, y].live == false && grid[x + 1, y].visited == false)
                {
                    grid[x + 1, y].visited = true;
                    if (grid[x + 1, y].liveneighbors == 0)
                    {
                        RecursiveTest(x + 1, y);
                    }
                }
                if (y + 1 < size)
                {
                    if (grid[x + 1, y + 1].live == false && grid[x + 1, y + 1].visited == false)
                    {
                        grid[x + 1, y + 1].visited = true;
                        if (grid[x + 1, y + 1].liveneighbors == 0)
                        {
                            RecursiveTest(x + 1, y + 1);
                        }
                    }
                }
                if (y > 0)
                {
                    if (grid[x + 1, y - 1].live == false && grid[x + 1, y - 1].visited == false)
                    {
                        grid[x + 1, y - 1].visited = true;
                        if (grid[x + 1, y - 1].liveneighbors == 0)
                        {
                            RecursiveTest(x + 1, y - 1);
                        }
                    }
                }
            }
            if (y + 1 < size)
            {
                if (grid[x, y + 1].live == false && grid[x, y + 1].visited == false)
                {
                    grid[x, y + 1].visited = true;
                    if (grid[x, y + 1].liveneighbors == 0)
                    {
                        RecursiveTest(x, y + 1);
                    }
                }
            }
            if (x > 0)
            {
                if (grid[x - 1, y].live == false && grid[x - 1, y].visited == false)
                {
                    grid[x - 1, y].visited = true;
                    if (grid[x - 1, y].liveneighbors == 0)
                    {
                        RecursiveTest(x - 1, y);
                    }
                }
                if (y + 1 < size)
                {
                    if (grid[x - 1, y + 1].live == false && grid[x - 1, y + 1].visited == false)
                    {
                        grid[x - 1, y + 1].visited = true;
                        if (grid[x - 1, y + 1].liveneighbors == 0)
                        {
                            RecursiveTest(x - 1, y + 1);
                        }
                    }
                }
                if (y > 0)
                {
                    if (grid[x - 1, y - 1].live == false && grid[x - 1, y - 1].visited == false)
                    {
                        grid[x - 1, y - 1].visited = true;
                        if (grid[x - 1, y - 1].liveneighbors == 0)
                        {
                            RecursiveTest(x - 1, y - 1);
                        }
                    }
                }
            }
            if (y > 0)
            {
                if (grid[x, y - 1].live == false && grid[x, y - 1].visited == false)
                {
                    grid[x, y - 1].visited = true;
                    if (grid[x, y - 1].liveneighbors == 0)
                    {
                        RecursiveTest(x, y - 1);
                    }
                }
            }
        }

    }
}
