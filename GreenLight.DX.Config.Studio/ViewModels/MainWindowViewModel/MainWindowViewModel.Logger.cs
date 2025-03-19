using GreenLight.DX.Shared.Hermes.Models;
using GreenLight.DX.Shared.Hermes.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class MainWindowViewModel
    {
        private IHermesService? _logger;
        private static readonly string _logContext = nameof(MainWindowViewModel);

        private void Info(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Info);
        private void Error(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Error);
        private void Warn(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Warning);
        private void Debug(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Debug);

        public void InitializeLogger()
        {
            _logger = _services.GetService<IHermesService>();
        }
    }
}
