using GreenLight.DX.Config.Studio.Events;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class MainWindowViewModel
    {
        public event EventHandler? Initialized;
        private IEventAggregator _eventAggregator;


        public void OnConfigurationPropertyChanged(ConfigurationPropertyChangedEventArgs e)
        {
            ValidateUniqueNames();
        }

        public void OnConfigurationDeleted(ConfigurationViewModel configToDelete)
        {
            try
            {
                _configurationService.Project.Configurations.Remove(configToDelete.Model); // Remove from Model
                Debug($"Configuration '{configToDelete.Name}' deleted.", context: "OnConfigurationDeleted");
            }
            catch (Exception ex)
            {
                Error($"Error deleting configuration: {ex.Message}", context: "OnConfigurationDeleted");
            }
        }

        public void InitializeEvents()
        {
            _eventAggregator = _services.GetRequiredService<IEventAggregator>();
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Subscribe(OnConfigurationDeleted);
            _eventAggregator.GetEvent<ConfigurationPropertyChangedEvent>().Subscribe(OnConfigurationPropertyChanged);
        }
    }
}
