using Newtonsoft.Json;
using System;
using System.IO;

namespace TicketingScreenDesigner.Helpers
{
    public class ErrorLog
    {
        public DateTime ErrorTime { get; set; }
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
                ErrorTime = DateTime.Now,
                Message = message,
                StackTrace = stackTrace
            };

            string json = JsonConvert.SerializeObject(log, Formatting.Indented);
            File.AppendAllText(logFilePath, json + "," + Environment.NewLine);
        }
    }
}
