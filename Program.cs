using System;

namespace RockPaperScissors
{
    internal class Program
    {
        private static void Main(string[] moves)
        {
            ValidateMoves(moves);

            GameController(moves);
        }

        private static void ValidateMoves(string[] moves)
        {
            if(moves.Length < 3)
            {
                Console.WriteLine("\nThe number of possible moves must be greater than or equal to 3! Try again!\n");
                Environment.Exit(0);
            }

            if(moves.Length % 2 == 0)
            {
                Console.WriteLine("\nThe number of possible moves must be odd! Try again!\n");
                Environment.Exit(0);
            }

            for (int i = 0; i < moves.Length; i++) 
            {
                for (int j = i + 1; j < moves.Length; j++) 
                {
                    if (moves[i].ToLower() == moves[j].ToLower()) 
                    {
                        Console.WriteLine("\nPossible moves must be different! Try again!\n");
                        Environment.Exit(0);
                    }
                }
            }
        } 

        private static void GameController(string[] moves)
        {
            int computerChoice = new Random().Next(0, moves.Length);
            string HMAC = Encryptor.GenerateHMAC(moves[computerChoice]);

            PrintMainMenu(moves, HMAC);

            int userChoice;
            HandleUserChoice(out userChoice, moves.Length);
            
            if(userChoice == 0)
            {
                Console.WriteLine("\nGood bye!\nThanks for playing!\n");
                Environment.Exit(0);
            }
            
            if(userChoice == -999)
            {
                HelpTable.Print(moves);
                Console.WriteLine("\nChoose your move: ");
                HandleUserChoice(out userChoice, moves.Length);
            }

            Console.WriteLine($"\nYou chose move: {moves[--userChoice]}");
            Console.WriteLine($"Computer chose move: {moves[computerChoice]}\n");

            if(moves[userChoice] == moves[computerChoice])
            {
                Console.WriteLine("Dead heat...");
            }
            else if(Rules.IsWon(moves, userChoice, computerChoice))
            {
                Console.WriteLine("You Won!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }

            Console.WriteLine($"\nHMAC: {HMAC}\n");
        }

        private static void PrintMainMenu(string[] moves, string HMAC) 
        {
            Console.WriteLine($"\nHMAC: {HMAC}\n");
            Console.WriteLine("Choose one of the available moves:\n");

            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }


            Console.WriteLine("0 - exit\n? - help");
            Console.Write("Enter your move: ");
        }

        private static void HandleUserChoice(out int userChoice, int numberOfMoves)
        {
            string? userInput = Console.ReadLine();

            bool correctUserChoice = int.TryParse(userInput, out userChoice);

            if(userInput == null || (correctUserChoice == false && userInput != "?"))
            {
                Console.WriteLine("Invalid Enter!\nTry again!");
                Environment.Exit(0);
            }

            if(correctUserChoice == false && userInput == "?")
            {
                userChoice = -999;
            }

            if(correctUserChoice && (userChoice > numberOfMoves || userChoice < 0))
            {
                Console.WriteLine("Check ordinal number of the move!\nTry again!");
                Environment.Exit(0);
            }
        }
    }
}