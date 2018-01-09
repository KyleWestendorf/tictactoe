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
                    string playerOne = "";
                    string playerTwo = "";
                    string players = "1";

                    Console.WriteLine("Do you want to Play as X or O?");
                    Console.WriteLine("1. X");
                    Console.WriteLine("2. O");
                    string side = Console.ReadLine();
                    if (side == "1")
                    {
                        playerOne = "X";
                        playerTwo = "O";
                    }
                    else
                    {
                        playerOne = "X";
                        playerTwo = "O";
                    }
                    Console.WriteLine("You chose {0}", side);
                    NewAITurn(players, board, playerOne, playerTwo, turn, counter);
                    Console.ReadLine();


                }

             // Player Two Game
                else if (answer == "2")
                {
                    string players = "2";
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

                    NewTurn(players, board, playerOne, playerTwo, turn, counter);

                    Console.ReadLine();
                }
                Console.ReadLine();
                menu = false;


            }// end of while
        } // End of NewGame();

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

            private static void NewTurn(string players, string[] board, string playerOne, string playerTwo, string turn, int counter)
            {
            if (players == "2")
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
                NewTurn(players, board, playerOne, playerTwo, turn, counter);
            } else
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
                NewTurn(players, board, playerOne, playerTwo, turn, counter);
            }

            }

        private  static void AiTurn(string[] board, int counter, string playerTwo)
        {
            string move = CheckWinningMove(board);
            Console.WriteLine("This is the move: {0}", move);
            int AIChoice = 0;

            Int32.TryParse(move, out AIChoice);
            
            if (move != "")
            {
                board[AIChoice] = playerTwo;
            }
            else if (board[4] == "4" && counter == 1)
            {
                board[4] = playerTwo;
            }
            else if (board[0] == "0")
            {
                board[0] = playerTwo;
            }
            else if (board[8] == "0")
            {
                board[0] = playerTwo;
            }
            else if (board[2] == "2")
            {
                board[2] = playerTwo;
            }
            else if (board[6] == "6")
            {
                board[6] = playerTwo;
            }
        }

        private static string CheckWinningMove(string[] board)
        {
            string winner = "";
            if ((board[0] == board[1]) && (board[2] == "2"))
            {
                winner = board[2];
            }
            else if ((board[1] == board[2]) && (board[0] == "0"))
            {
                winner = board[0];
            }
            else if ((board[0] == board[2]) && (board[1] == "1"))
            {
                winner = board[1];
            }
            else if ((board[3] == board[4]) && (board[5] == "5"))
            {
                winner = board[5];
            }
            else if ((board[4] == board[5]) && (board[3] == "3"))
            {
                winner = board[3];
            }
            else if ((board[3] == board[5]) && (board[4] == "4"))
            {
                winner = board[4];
            }
            else if ((board[6] == board[7]) && (board[8] == "8"))
            {
                winner = board[8];
            }
            else if ((board[7] == board[8]) && (board[6] == "6"))
            {
                winner = board[6];
            }
            else if ((board[8] == board[6]) && (board[7] == "7"))
            {
                winner = board[7];
            }
            if ((board[0] == board[3]) && (board[6] == "6"))
            {
                winner = board[6];
            }
            else if ((board[3] == board[6]) && (board[0] == "0"))
            {
                winner = board[0];
            }
            else if ((board[0] == board[6]) && (board[3] == "3"))
            {
                winner = board[3];
            }
            else if ((board[1] == board[4]) && (board[7] == "7"))
            {
                winner = board[7];
            }
            else if ((board[4] == board[7]) && (board[1] == "1"))
            {
                winner = board[1];
            }
            else if ((board[1] == board[7]) && (board[4] == "4"))
            {
                winner = board[4];
            }
            else if ((board[2] == board[5]) && (board[8] == "8"))
            {
                winner = board[8];
            }
            else if ((board[5] == board[8]) && (board[2] == "2"))
            {
                winner = board[2];
            }
            else if ((board[8] == board[2]) && (board[5] == "5"))
            {
                winner = board[5];
            }
            else if ((board[0] == board[4]) && (board[8] == "8"))
            {
                winner = board[8];
            }
            else if ((board[0] == board[8]) && (board[4] == "4"))
            {
                winner = board[4];
            }
            else if ((board[4] == board[8]) && (board[0] == "0"))
            {
                winner = board[0];
            }
            else if ((board[2] == board[4]) && (board[6] == "6"))
            {
                winner = board[6];
            }
            else if ((board[2] == board[6]) && (board[4] == "4"))
            {
                winner = board[4];
            }
            else if ((board[4] == board[6]) && (board[2] == "2"))
            {
                winner = board[2];
            }
            return winner;
        }

        private static void CheckWin(string[] board, int counter)
            {
            if (board[0] == board[1] && board[1] == board[2])
            {
                Winner(board);
            }
            else if (board[3] == board[4] && board[4] == board[5])
            {
                Winner(board);
            }
            else if (board[6] == board[7] && board[7] == board[8])
            {
                Winner(board);
            }
            else if (board[0] == board[3] && board[3] == board[6])
            {
                Winner(board);
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                Winner(board);
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                Winner(board);
            }
            else if (board[0] == board[4] && board[4] == board[8])
            {
                Winner(board);
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                Winner(board);

            }
            else if (counter >= 8)
            {
                Console.WriteLine("Draw!");
                ShowBoard(board);
                Console.ReadLine();
                Replay();
            }


            }

        private static void Winner(string[] board)
        {
            Console.WriteLine("Winner!");
            ShowBoard(board);
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
        // One player Methods
        public static void NewAITurn(string players, string[] board, string playerOne, string playerTwo, string turn, int counter)
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

                AiTurn(board, counter, playerTwo);
                CheckWin(board, counter);
                turn = "playerOne";
                counter++;
            }

            Console.WriteLine("This is the counter: {0}", counter);
            NewAITurn(players, board, playerOne, playerTwo, turn, counter);

        }
    }
}
