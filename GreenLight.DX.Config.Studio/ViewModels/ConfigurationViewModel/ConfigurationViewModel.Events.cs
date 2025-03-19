using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Events;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class ConfigurationViewModel
    {
        private IEventAggregator _eventAggregator;

        public void InitializeEvents()
        {
            _eventAggregator = _services.GetRequiredService<IEventAggregator>();

            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<SettingItem>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<AssetItem>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<ResourceItem>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<SettingItem>>().Subscribe(OnRowPropertyChange);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<AssetItem>>().Subscribe(OnRowPropertyChange);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceItem>>().Subscribe(OnRowPropertyChange);

        }

        public void RaisePropertyChangedEvent(string? propertyName)
        {
            if (_eventAggregator == null) return;
            _eventAggregator.GetEvent<ConfigurationPropertyChangedEvent>().Publish(new ConfigurationPropertyChangedEventArgs()
            {
                ViewModel = this,
                EventArgs = new PropertyChangedEventArgs(propertyName)
            });
        }

        public void OnRowPropertyChange<T>(ConfigurationRowPropertyChangedEventArgs<T> rowViewModel) where T : ConfigItem
        {
            ValidateUniqueKeys();
        }

        public void OnConfigurationRowDeleted<T>(ConfigurationRowViewModel<T> rowViewModel) where T : ConfigItem
        {
            if (rowViewModel != null)
            {
                if (rowViewModel is SettingRowViewModel model) Model.Settings.Remove(model.Model);
                if (rowViewModel is AssetRowViewModel model1) Model.Assets.Remove(model1.Model);
                if (rowViewModel is ResourceRowViewModel model2) Model.Resources.Remove(model2.Model);
            }
        }
    }
}
