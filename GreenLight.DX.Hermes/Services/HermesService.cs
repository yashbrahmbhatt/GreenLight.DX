using GreenLight.DX.Hermes.Models;
using GreenLight.DX.Hermes.ViewModels;
using GreenLight.DX.Hermes.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GreenLight.DX.Hermes.Services
{
    public class HermesService : IHermesService
    {
        public ObservableCollection<LogMessage> Logs { get; }
        private HermesWindow _hermesWindow;
        private readonly Dispatcher _dispatcher; // Store the dispatcher
        private readonly HermesWindowViewModel _hermesWindowViewModel;

        public HermesService(Dispatcher dispatcher) // Inject the dispatcher
        {
            Logs = new ObservableCollection<LogMessage>();
            _dispatcher = dispatcher; // Initialize dispatcher
            _hermesWindowViewModel = new HermesWindowViewModel(this, 1);
        }
        public void Info(string context, string message) => Log(message, context, LogLevel.Info);
        public void Warning(string context, string message) => Log(message, context, LogLevel.Warning);
        public void Error(string context, string message) => Log(message, context, LogLevel.Error);
        public void Debug(string context, string message) => Log(message, context, LogLevel.Debug);

        public void Log(string message, string context, LogLevel level)
        {
            var logMessage = new LogMessage(DateTime.Now, level, message, context);
            Log(logMessage); // Call the overload
        }

        public void Log(LogMessage logMessage)
        {
            _dispatcher.Invoke(() => // Use the stored dispatcher
            {
                Logs.Add(logMessage);
            });
        }
        public void ShowHermesWindow()
        {
            if (_hermesWindow == null)
            {
                _dispatcher.Invoke(() =>
                {
                    _hermesWindow = new HermesWindow(_hermesWindowViewModel);
                    // Use resolved ViewModel
                    _hermesWindow.Closed += HermesWindow_Closed;
                    _hermesWindow.Show();
                });
            }
            else
            {
                _dispatcher.Invoke(() =>
                {
                    if (_hermesWindow.WindowState == WindowState.Minimized)
                    {
                        _hermesWindow.WindowState = WindowState.Normal;
                    }
                    _hermesWindow.Activate(); // Bring the window to the front
                });

            }
        }

        public void CloseHermesWindow()
        {
            _dispatcher.Invoke(() =>
            {
                if (_hermesWindow != null)
                {
                    _hermesWindow.Close();
                }
            });
        }

        private void HermesWindow_Closed(object sender, EventArgs e)
        {
            _hermesWindow = null; // Release the reference when the window is closed
        }
    }
}
