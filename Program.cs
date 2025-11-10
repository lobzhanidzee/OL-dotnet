using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman_project
{
    internal class Program
    {
        private static readonly StatsManager _statsManager = new StatsManager("stats.txt");

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Play Hangman");
                Console.WriteLine("2. View High Scores");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                if (string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        PlayGame();
                        break;
                    case "2":
                        DisplayHighScores();
                        break;
                    case "3":
                        Console.WriteLine("Thanks for playing!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void PlayGame()
        {
            string? playerName;
            do
            {
                Console.Write("Please enter your name: ");
                playerName = Console.ReadLine();
            } while (string.IsNullOrEmpty(playerName));

            string selectedWord = WordManager.GetRandomWordFromFile("words.txt");
            var game = new HangmanGame(selectedWord);

            while (game.State == GameState.InProgress)
            {
                game.DisplayGameState();
                char letter = game.GetLetterInput();

                try
                {
                    bool validGuess = game.MakeGuess(letter);
                    if (!validGuess)
                    {
                        game.DisplayAlreadyGuessed();
                    }
                }
                catch (ArgumentException ex)
                {
                    string message = game.DisplayInvalidInput();
                    Logger.Log(ex, message);
                }
            }

            bool hasWon = game.State == GameState.Won;
            if (hasWon)
            {
                game.DisplayWin();
            }
            else
            {
                game.DisplayLoss();
            }

            _statsManager.UpdateStats(playerName, hasWon);
        }

        private static void DisplayHighScores()
        {
            Console.WriteLine("\n--- High Scores ---");
            var highScores = _statsManager.GetHighScores();

            if (highScores.Count == 0)
            {
                Console.WriteLine("No scores yet!");
                return;
            }

            foreach (var score in highScores)
            {
                Console.WriteLine($"- {score.PlayerName}: {score.Wins} wins, {score.Losses} losses");
            }
        }
    }
}
