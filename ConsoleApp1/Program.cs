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

            NewGame();

            }// end of main

        private static void NewGame()
        {
            bool menu = true;
            string[] board = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string positionOne = board[0];
            string positionTwo = board[1];
            string positionThree = board[2];
            string positionFour = board[3];
            string positionFive = board[4];
            string positionSix = board[5];
            string positionSeven = board[6];
            string positionEight = board[7];
            string positionNine = board[8];
            string turn = "playerOne";
            int counter = 0;


            while (menu == true)
            {
                Console.WriteLine("1. One Player");
                Console.WriteLine("2. Two Player");
                Console.WriteLine("One or two?");
                string answer = Console.ReadLine();

                // Player One Game
                if (answer == "1")
                {


                    Console.WriteLine("Do you want to Play as X or O?");
                    Console.WriteLine("1. X");
                    Console.WriteLine("2. O");
                    string side = Console.ReadLine();
                    if (side == "1")
                    {
                        side = "X";
                    }
                    else
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
                    }
                    else
                    {
                        playerOne = "O";
                        playerTwo = "X";
                    }
                    Console.WriteLine("You chose {0}. Player Two is {1}", playerOne, playerTwo);

                    NewTurn(board, playerOne, playerTwo, turn, counter);

                    Console.ReadLine();
                }
                Console.ReadLine();
                menu = false;


            }// end of while
        }

        private static void PlayerTurn(string player, string[] board, string playerOne, string playerTwo)
            {
                Console.WriteLine("Player {0}, where would you like to play? (Board position 0-8)", player);
                ShowBoard(board);

                int choice = Convert.ToInt32(Console.ReadLine());
                if (board[choice] != "X" && board[choice] != "O")
                {
                    if (player == "One")
                    {

                        board[choice] = playerOne;
                    }
                    else
                    {
                        board[choice] = playerTwo;
                    }
                } else
                {
                    Console.WriteLine("Invalid selection!");
                    PlayerTurn(player, board, playerOne, playerTwo);
                }
            }

            public static void ShowBoard(string[] board)
            {
                Console.WriteLine("{0} | {1} | {2}", board[0], board[1], board[2]);
                Console.WriteLine("{0} | {1} | {2}", board[3], board[4], board[5]);
                Console.WriteLine("{0} | {1} | {2}", board[6], board[7], board[8]);
            }

            private static void NewTurn(string[] board, string playerOne, string playerTwo, string turn, int counter)
            {

                while (turn == "playerOne")
                {
                    string player = "One";
                    PlayerTurn(player, board, playerOne, playerTwo);
                    CheckWin(board, counter);
                    turn = "playerTwo";
                    counter++;
                }
                while (turn == "playerTwo")
                {
                    string player = "Two";
                    PlayerTurn(player, board, playerOne, playerTwo);
                    CheckWin(board, counter);
                    turn = "playerOne";
                    counter++;
                }

                Console.WriteLine("This is the counter: {0}", counter);
                NewTurn(board, playerOne, playerTwo, turn, counter);

            }

            private static void CheckWin(string[] board, int counter)
            {
                if (board[0] == board[1] && board[1] == board[2])
                {
                    Winner();
                }
                else if (board[3] == board[4] && board[4] == board[5])
                {
                    Winner();
            }
                else if (board[6] == board[7] && board[7] == board[8])
                {
                    Winner();
            }
                else if (board[0] == board[3] && board[3] == board[6])
                {
                    Winner();
            }
                else if (board[1] == board[4] && board[4] == board[7])
                {
                     Winner();
            }
                else if (board[2] == board[5] && board[5] == board[8])
                {
                     Winner();
            }
                else if (board[0] == board[4] && board[4] == board[8])
                {
                     Winner();
            }
                else if (board[2] == board[4] && board[4] == board[6])
                {
                     Winner();
                
            } else if (counter >= 8)
                {
                    Console.WriteLine("Draw!");
                    Console.ReadLine();
                    Replay();
                }


            }

        private static void Winner()
        {
            Console.WriteLine("Winner!");
            Console.ReadLine();
            Replay();
        }

        private static void Replay()
        {
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string response = Console.ReadLine();
            if (response == "1")
            {
                NewGame();
            }
            if (response == "2")
            {

                Console.WriteLine("Thanks for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid entry!");
                Replay();

            }
        }
    }
}
