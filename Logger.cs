
using System;
using System.IO;

namespace Hangman_project
{
    public static class Logger
    {
        private const string LogFilePath = "errors.log";

        public static void Log(Exception ex)
        {
            Log(ex, ex.Message);
        }

        public static void Log(Exception ex, string message)
        {
            LogToFile(ex, message);
        }

        private static void LogToFile(Exception ex, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().Name}: {message}");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Failed to log error: {logEx.Message}");
            }
        }
    }
}
