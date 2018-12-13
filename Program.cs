using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227Milestone1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            while (success == false)
            {
                Console.WriteLine("Enter an integer to determine the size of each side of the square:");
                if (Int32.TryParse(Console.ReadLine(), out int size))
                {
                    success = true;
                    Board board = new Board(size);
                    board.Activate();
                    board.NeighborCount();
                    Console.WriteLine();
                    Console.WriteLine("Here is your " + size + " X " + size + " game board");
                    board.Display();
                    Console.WriteLine();
                    Console.WriteLine("Enter 'Y' to make another, or hit enter to exit");
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