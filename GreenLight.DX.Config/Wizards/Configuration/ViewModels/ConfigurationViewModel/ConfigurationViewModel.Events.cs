using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Wizards.Configuration.Events;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class ConfigurationViewModel
    {
        private IEventAggregator _eventAggregator;

        public void InitializeEvents()
        {
            _eventAggregator = _services.GetRequiredService<IEventAggregator>();

            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<SettingItemModel>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<AssetItemModel>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<ResourceItemModel>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<SettingItemModel>>().Subscribe(OnRowPropertyChange);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<AssetItemModel>>().Subscribe(OnRowPropertyChange);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceItemModel>>().Subscribe(OnRowPropertyChange);

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

        public void OnRowPropertyChange<T>(ConfigurationRowPropertyChangedEventArgs<T> rowViewModel) where T : ConfigItemModel
        {
            ValidateUniqueKeys();
        }

        public void OnConfigurationRowDeleted<T>(ConfigurationRowViewModel<T> rowViewModel) where T : ConfigItemModel
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
