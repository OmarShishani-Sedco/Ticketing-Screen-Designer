using Newtonsoft.Json;
using System;
using System.IO;

namespace TicketingScreenDesigner.Common.Helpers
{
    public class ErrorLog
    {
        public string ErrorTime { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }

    public static class Logger
    {
        private static readonly string logFilePath = "error_log.json";

        public static void LogError(string message, string stackTrace = "")
        {
            var log = new ErrorLog
            {
                ErrorTime = DateTime.Now.ToString(),
                Message = message,
                StackTrace = stackTrace
            };

            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            File.AppendAllText(logFilePath, json + "," + Environment.NewLine);
        }

        public static void LogError(Exception ex, string context = "")
        {
            var log = new ErrorLog
            {
                ErrorTime = DateTime.Now.ToString(),
                Message = $"[{context}] {ex.Message}",
                StackTrace = ex.StackTrace ?? "No stack trace available"
            };

            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            File.AppendAllText(logFilePath, json + "," + Environment.NewLine);
        }
    }

}
