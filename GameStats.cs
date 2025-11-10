namespace Hangman_project
{
    public class GameStats
    {
        public string PlayerName { get; set; }

        public GameStats(string playerName)
        {
            PlayerName = playerName;
        }

        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}