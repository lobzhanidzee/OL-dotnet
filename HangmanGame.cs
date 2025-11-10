namespace Hangman_project
{
    internal class HangmanGame
    {
        private readonly WordManager _wordManager;
        private readonly Lives _livesManager;
        private GameState _gameState;
        private char _lastGuess;

        public HangmanGame(string word, int maxIncorrectGuesses = 6)
        {
            _wordManager = new WordManager(word);
            _livesManager = new Lives(maxIncorrectGuesses);
            _gameState = GameState.InProgress;
            _lastGuess = '\0';
        }

        public GameState State => _gameState;

        public string DisplayWord => _wordManager.GetDisplayWord();

        public int RemainingGuesses => _livesManager.RemainingGuesses;

        public HashSet<char> GuessedLetters => _wordManager.GuessedLetters;

        public List<char> IncorrectLetters => _wordManager.IncorrectLetters;

        public string Solution => _wordManager.Word;

        public char LastGuess => _lastGuess;

        public bool MakeGuess(char letter)
        {
            if (_gameState != GameState.InProgress)
                throw new InvalidOperationException("Game is not in progress");

            if (!char.IsLetter(letter))
                throw new ArgumentException("Input must be a letter");

            if (_wordManager.HasBeenGuessed(letter))
                return false;

            _lastGuess = char.ToUpper(letter);
            bool isCorrect = _wordManager.GuessLetter(letter);

            if (!isCorrect)
            {
                _livesManager.RecordIncorrectGuess();
            }

            UpdateGameState();
            return true;
        }

        private void UpdateGameState()
        {
            if (_wordManager.IsWordComplete())
            {
                _gameState = GameState.Won;
            }
            else if (_livesManager.IsGameOver())
            {
                _gameState = GameState.Lost;
            }
        }

        public void DisplayGameState()
        {
            string incorrect = IncorrectLetters.Count > 0
                ? string.Join("", IncorrectLetters)
                : "";
            char guess = LastGuess != '\0' ? LastGuess : ' ';

            Console.WriteLine($"Word: {DisplayWord} | Remaining: {RemainingGuesses} | Incorrect: {incorrect} | Guess: {guess}");
        }

        public void DisplayWin()
        {
            Console.WriteLine("You won!");
        }

        public void DisplayLoss()
        {
            Console.WriteLine($"You lost! The word was: {Solution}");
        }

        public char GetLetterInput()
        {
            Console.Write("Enter a letter: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
                return '\0';

            return input[0];
        }

        public void DisplayAlreadyGuessed()
        {
            Console.WriteLine("You already guessed that letter! Try again.");
        }

        public string DisplayInvalidInput()
        {
            string message = "Invalid input! Please enter a letter.";
            Console.WriteLine(message);
            return message;
        }
    }
}
