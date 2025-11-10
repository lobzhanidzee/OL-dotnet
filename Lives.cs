namespace Hangman_project
{
    internal class Lives
    {
        private readonly int _maxIncorrectGuesses;
        private int _incorrectGuesses;

        public Lives(int maxIncorrectGuesses = 6)
        {
            _maxIncorrectGuesses = maxIncorrectGuesses;
            _incorrectGuesses = 0;
        }

        public int IncorrectGuesses => _incorrectGuesses;

        public int RemainingGuesses => _maxIncorrectGuesses - _incorrectGuesses;

        public int MaxIncorrectGuesses => _maxIncorrectGuesses;

        public void RecordIncorrectGuess()
        {
            _incorrectGuesses++;
        }

        public bool IsGameOver()
        {
            return _incorrectGuesses >= _maxIncorrectGuesses;
        }
    }
}
