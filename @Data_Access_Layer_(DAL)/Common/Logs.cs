using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD.DAL.Common
{
    /// <summary>
    /// Provides thread-safe, asynchronous logging functionality for the Data Access Layer.
    /// </summary>
    internal class Logs
    {
        /// <summary>
        /// Specifies the severity level of the log entry.
        /// </summary>
        public enum enType { Error = 0, Info = 1 }

        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static readonly string _logFilePath = Path.Combine(AppContext.BaseDirectory, "dvld.log");

        /// <summary>
        /// Formats the log message with a timestamp and severity level.
        /// </summary>
        private static string _PrepareLogLine(enType typeOfLog, string logDetails)
        {
            string timestamp = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            string typeString = typeOfLog switch
            {
                enType.Error => "Error",
                enType.Info => "Info",
                _ => typeOfLog.ToString()
            };

            return $"[{timestamp}] {typeString}: {logDetails}{Environment.NewLine}";
        }

        /// <summary>
        /// Asynchronously appends a formatted log entry to the application's log file in a thread-safe manner.
        /// </summary>
        internal static async Task AppendLog(enType typeOfLog, string logDetails)
        {
            string logLine = _PrepareLogLine(typeOfLog, logDetails);

            await _semaphore.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(_logFilePath, logLine);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}