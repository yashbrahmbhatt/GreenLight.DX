using GreenLight.DX.Hermes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GreenLight.DX.Hermes.Services
{
    public class HermesConsumer
    {
        private static IHermesService? _logger;
        private static string? _logContext;

        private void Info(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Info);
        private void Error(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Error);
        private void Warn(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Warning);
        private void Debug(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Debug);

        public void InitializeLogger(IServiceProvider services, string context)
        {
            _logContext = context;
            _logger = services.GetService<IHermesService>();
        }
    }
}
