using GreenLight.DX.Config.Services.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ConfigurationService _configurationService;

        public void InitializeConfigurationService()
        {
            Debug("Entering InitializeConfigurationService", nameof(InitializeConfigurationService)); // Added logging

            try
            {
                _configurationService = _services.GetRequiredService<ConfigurationService>();
                Debug("Successfully obtained ConfigurationService via dependency injection", nameof(InitializeConfigurationService)); // Added logging
            }
            catch (Exception ex)
            {
                Error($"Failed to obtain ConfigurationService: {ex.Message}", nameof(InitializeConfigurationService)); // Using Debug as an example if Error doesn't exist
                throw; // Re-throw the exception as the ViewModel cannot function without the service
            }
        }
    }
}
