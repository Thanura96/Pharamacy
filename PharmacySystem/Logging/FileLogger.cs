using System;
using System.IO;

namespace PharmacySystem.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;
        private readonly object _lock = new object();

        public FileLogger()
        {
            string logDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PharmacySystem",
                "Logs");

            Directory.CreateDirectory(logDirectory);
            _logFilePath = Path.Combine(logDirectory, $"pharmacy_{DateTime.Now:yyyyMMdd}.log");
        }

        public void LogInfo(string message)
        {
            WriteEntry("INFO", message, null);
        }

        public void LogWarning(string message)
        {
            WriteEntry("WARN", message, null);
        }

        public void LogError(string message, Exception exception = null)
        {
            WriteEntry("ERROR", message, exception);
        }

        private void WriteEntry(string level, string message, Exception exception)
        {
            lock (_lock)
            {
                try
                {
                    string entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    if (exception != null)
                    {
                        entry += Environment.NewLine + exception;
                    }

                    File.AppendAllText(_logFilePath, entry + Environment.NewLine);
                }
                catch
                {
                    // Avoid recursive logging failures from breaking the application.
                }
            }
        }
    }
}
