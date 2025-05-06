using GreenLight.DX.Hermes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Hermes.Services
{
    public interface IHermesService
    {
        ObservableCollection<LogMessage> Logs { get; }
        public void Info(string context, string message);
        public void Warning(string context, string message);
        public void Error(string context, string message);
        public void Debug(string context, string message);
        void Log(string message, string context, LogLevel level);
        void Log(LogMessage logMessage); // Overload to accept LogMessage directly

        void ShowHermesWindow();
        void CloseHermesWindow();

    }
}
