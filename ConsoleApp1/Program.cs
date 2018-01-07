using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu == true)
            {
                Console.WriteLine("1. One Player");
                Console.WriteLine("2. Two Player");
                Console.WriteLine("One or two?");
                string answer = Console.ReadLine();

          // Player One Game
                if(answer == "1") {


                    Console.WriteLine("Do you want to Play as X or O?");
                    Console.WriteLine("1. X");
                    Console.WriteLine("2. O");
                    string side = Console.ReadLine();
                    if (side == "1")
                    {
                        side = "X";
                    } else
                    {
                        side = "O";
                    }
                    Console.WriteLine("You chose {0}", side);
                    Console.ReadLine();


                }

          // Player Two Game
                else if (answer == "2")
                    {
                        Console.WriteLine("1. X");
                        Console.WriteLine("2. O");
                        Console.WriteLine("Player One: Press 1 for X, two for O?");
                        string playerOne = Console.ReadLine();
                        string playerTwo;
                        if (playerOne == "1")
                    {
                        playerOne = "X";
                        playerTwo = "O";
                    } else
                    {
                        playerOne = "O";
                        playerTwo = "X";
                    }
                        Console.WriteLine("You chose {0}. Player Two is {1}", playerOne, playerTwo);
                        Console.ReadLine();
                    }
                Console.ReadLine();
                menu = false;
                
            }
        }
    }
}
