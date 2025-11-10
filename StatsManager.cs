using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hangman_project
{
    public class StatsManager
    {
        private readonly string _filePath;

        public StatsManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<GameStats> LoadStats()
        {
            if (!File.Exists(_filePath))
            {
                return new List<GameStats>();
            }

            var stats = new List<GameStats>();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    stats.Add(new GameStats(parts[0])
                    {
                        GamesPlayed = int.Parse(parts[1]),
                        Wins = int.Parse(parts[2]),
                        Losses = int.Parse(parts[3])
                    });
                }
            }
            return stats;
        }

        public void SaveStats(List<GameStats> stats)
        {
            var lines = stats.Select(s => $"{s.PlayerName},{s.GamesPlayed},{s.Wins},{s.Losses}");
            File.WriteAllLines(_filePath, lines);
        }

        public void UpdateStats(string playerName, bool hasWon)
        {
            var stats = LoadStats();
            var playerStats = stats.FirstOrDefault(s => s.PlayerName.Equals(playerName, System.StringComparison.OrdinalIgnoreCase));

            if (playerStats == null)
            {
                playerStats = new GameStats(playerName);
                stats.Add(playerStats);
            }

            playerStats.GamesPlayed++;
            if (hasWon)
            {
                playerStats.Wins++;
            }
            else
            {
                playerStats.Losses++;
            }

            SaveStats(stats);
        }

        public List<GameStats> GetHighScores(int topN = 5)
        {
            return LoadStats().OrderByDescending(s => s.Wins).Take(topN).ToList();
        }
    }
}
