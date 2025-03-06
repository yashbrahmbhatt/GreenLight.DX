using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Shared.Hermes.Models
{
    public class LogMessage
    {
        public DateTime Timestamp { get; }
        public LogLevel Level { get; }
        public string Message { get; }
        public string Context { get; }

        public LogMessage(DateTime timestamp, LogLevel level, string message, string context)
        {
            Timestamp = timestamp;
            Level = level;
            Message = message;
            Context = context;
        }

        public override string ToString()
        {
            return $"[{GetTimestamp(Timestamp)}] [{Level}] [{Context}] {Message}";
        }

        private string GetTimestamp(DateTime dateTime) => dateTime.ToString("HH:mm:ss");
    }
}
