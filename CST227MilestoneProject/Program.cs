using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227MilestoneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            while (success == false)
            {
                Console.Clear();
                Console.WriteLine("Enter an integer to determine the size of each side of the square:");
                if (Int32.TryParse(Console.ReadLine(), out int size))
                {
                    success = true;
                    MinesweeperGame game = new MinesweeperGame(size);
                    Console.Clear();
                    Console.WriteLine();
                    game.PlayGame();
                    Console.WriteLine();
                    Console.WriteLine("Enter 'Y' to play again, or hit enter to exit");
                    string again = Console.ReadLine();
                    if (again == "Y" || again == "y")
                    {
                        success = false;
                    }
                }
                else
                {
                    Console.WriteLine("Could not recognize input as an integer.");
                }
            }
        }
    }
}
