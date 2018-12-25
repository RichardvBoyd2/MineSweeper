using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227MilestoneProject
{
    class MinesweeperGame : Board, IPlayable
    {
        public MinesweeperGame(int size) : base(size)
        {
            Activate();
            NeighborCount();
        }

        //Override display method to hide unvisited cells
        public override void Display()
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (game[j, i].visited == false)
                    {
                        Console.Write(" ?");
                    }
                    else
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
                }
                Console.WriteLine();
            }
        }

        //test the whole board to see if the game has been won yet
        public bool Win(Cell[,] test)
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

        //runs the game within the console
        public void PlayGame()
        {
            bool gameover = false;
            //loop to keep the game going until 'game over' is true
            while (gameover == false)
            {
                Display();
                int x = -1, y = -1;
                while (x < 0 || x >= size)
                {
                    Console.WriteLine("Enter the column of the cell you would like to visit (starting from the left):");
                    if (Int32.TryParse(Console.ReadLine(), out x))
                    {
                        x--;
                        if (x < 0 || x >= size)
                        {
                            Console.WriteLine("Enter a number within the boundries of the board");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid integer");
                    }
                }
                while (y < 0 || y >= size)
                {
                    Console.WriteLine("Enter the row of the cell you would like to visit (starting from the top):");
                    if (Int32.TryParse(Console.ReadLine(), out y))
                    {
                        y--;
                        if (y < 0 || y >= size)
                        {
                            Console.WriteLine("Enter a number within the boundries of the board");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid integer");
                    }
                }
                Console.Clear();
                if (game[x, y].live == true)
                {
                    Console.WriteLine();
                    gameover = true;
                }
                else if (game[x, y].visited == true)
                {
                    Console.WriteLine("This cell has already been visited");
                }
                else if (game[x, y].liveneighbors == 0)
                {
                    Console.WriteLine();
                    game[x, y].visited = true;
                    RecursiveTest(x, y);
                }
                else
                {
                    Console.WriteLine();
                    game[x, y].visited = true;
                }
                if (Win(game))
                {
                    gameover = true;
                }
            }
            base.Display();
            Console.WriteLine();
            if (Win(game))
            {
                Console.WriteLine("You Win!");
            }
            else
            {
                Console.WriteLine("Game Over!");
            }
        }

        //Recursive method that reveals blocks of cell with no live neighbors when one is visited
        public void RecursiveTest (int x, int y)
        {
            if (x + 1 < size)
            {
                if (game[x + 1, y].live == false && game[x + 1, y].visited == false)
                {
                    game[x + 1, y].visited = true;
                    if (game[x + 1, y].liveneighbors == 0)
                    {
                        RecursiveTest(x + 1, y);
                    }
                }
                if (y + 1 < size)
                {
                    if (game[x + 1, y + 1].live == false && game[x + 1, y + 1].visited == false)
                    {
                        game[x + 1, y + 1].visited = true;
                        if (game[x + 1, y + 1].liveneighbors == 0)
                        {
                            RecursiveTest(x + 1, y + 1);
                        }
                    }
                }
                if (y > 0)
                {
                    if (game[x + 1, y - 1].live == false && game[x + 1, y - 1].visited == false)
                    {
                        game[x + 1, y - 1].visited = true;
                        if (game[x + 1, y - 1].liveneighbors == 0)
                        {
                            RecursiveTest(x + 1, y - 1);
                        }
                    }
                }
            }
            if (y + 1 < size)
            {
                if (game[x, y + 1].live == false && game[x, y + 1].visited == false)
                {
                    game[x, y + 1].visited = true;
                    if (game[x, y + 1].liveneighbors == 0)
                    {
                        RecursiveTest(x, y + 1);
                    }
                }
            }
            if (x > 0)
            {
                if (game[x - 1, y].live == false && game[x - 1, y].visited == false)
                {
                    game[x - 1, y].visited = true;
                    if (game[x - 1, y].liveneighbors == 0)
                    {
                        RecursiveTest(x - 1, y);
                    }
                }
                if (y + 1 < size)
                {
                    if (game[x - 1, y + 1].live == false && game[x - 1, y + 1].visited == false)
                    {
                        game[x - 1, y + 1].visited = true;
                        if (game[x - 1, y + 1].liveneighbors == 0)
                        {
                            RecursiveTest(x - 1, y + 1);
                        }
                    }
                }
                if (y > 0)
                {
                    if (game[x - 1, y - 1].live == false && game[x - 1, y - 1].visited == false)
                    {
                        game[x - 1, y - 1].visited = true;
                        if (game[x - 1, y - 1].liveneighbors == 0)
                        {
                            RecursiveTest(x - 1, y - 1);
                        }
                    }
                }
            }
            if (y > 0)
            {
                if (game[x, y - 1].live == false && game[x, y - 1].visited == false)
                {
                    game[x, y - 1].visited = true;
                    if (game[x, y - 1].liveneighbors == 0)
                    {
                        RecursiveTest(x, y - 1);
                    }
                }
            }           
        }
    }
}