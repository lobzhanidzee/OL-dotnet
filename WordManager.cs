using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Hangman_project
{
    public enum GameState
    {
        InProgress,
        Won,
        Lost
    }

    public class WordManager
    {
        private readonly string _word;
        private readonly HashSet<char> _guessedLetters;
        private readonly List<char> _incorrectLetters;

        public WordManager(string word)
        {
            _word = word.ToUpper();
            _guessedLetters = new HashSet<char>();
            _incorrectLetters = new List<char>();
        }

        public string Word => _word;

        public HashSet<char> GuessedLetters => _guessedLetters;

        public List<char> IncorrectLetters => _incorrectLetters;

        public bool HasBeenGuessed(char letter)
        {
            return _guessedLetters.Contains(char.ToUpper(letter));
        }

        public bool GuessLetter(char letter)
        {
            char upperLetter = char.ToUpper(letter);
            _guessedLetters.Add(upperLetter);
            bool isCorrect = _word.Contains(upperLetter);

            if (!isCorrect)
            {
                _incorrectLetters.Add(upperLetter);
            }

            return isCorrect;
        }

        public bool IsWordComplete()
        {
            return _word.All(c => _guessedLetters.Contains(c));
        }

        public string GetDisplayWord()
        {
            StringBuilder displayedLetters = new StringBuilder();
            foreach (char c in _word)
            {
                if (_guessedLetters.Contains(c))
                    displayedLetters.Append(c);
                else
                    displayedLetters.Append('_');
                displayedLetters.Append(' ');
            }
            return displayedLetters.ToString().TrimEnd();
        }

        public static string GetRandomWordFromFile(string filePath)
        {
            try
            {
                List<string> words = File.ReadAllLines(filePath).ToList();
                if (words == null || words.Count == 0)
                {
                    return "default";
                }
                Random rand = new Random();
                return words[rand.Next(0, words.Count)];
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return "default";
            }
        }
    }
}