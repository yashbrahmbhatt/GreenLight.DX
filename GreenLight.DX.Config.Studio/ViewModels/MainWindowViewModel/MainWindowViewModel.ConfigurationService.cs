using GreenLight.DX.Config.Shared.Services;
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
        private ConfigurationService _configurationService;

        public void InitializeConfigurationService()
        {
            _configurationService = _services.GetRequiredService<ConfigurationService>();
        }
    }
}
