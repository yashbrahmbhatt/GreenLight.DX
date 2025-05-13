using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Wizards.Configuration.Events;
using GreenLight.DX.Config.Wizards.Configuration.Windows;
using GreenLight.DX.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class ConfigurationViewModel
    {

        public ICommand AddSettingsRowCommand { get; set; }
        public ICommand AddAssetsRowCommand { get; set; }
        public ICommand AddResourcesRowCommand { get; set; }
        public ICommand DeleteConfigurationCommand { get; set; }

        public void InitializeCommands()
        {
            DeleteConfigurationCommand = new RelayCommand(OnDeleteConfiguration);
            AddSettingsRowCommand = new RelayCommand(OnSettingRowAdded);
            AddAssetsRowCommand = new RelayCommand(OnAssetRowAdded);
            AddResourcesRowCommand = new RelayCommand(OnResourceRowAdded);
        }
        public void OnSettingRowAdded()
        {
            var newSetting = new SettingItemModel(_services); // Create a new Model instance
            Model.Settings.Add(newSetting); // Add it directly to the Model
        }

        public void OnAssetRowAdded()
        {
            var newAsset = new AssetItemModel(_services);
            Model.Assets.Add(newAsset);
        }

        public void OnResourceRowAdded()
        {
            var newResource = new ResourceItemModel(_services);
            Model.Resources.Add(newResource);
        }

        public void OnDeleteConfiguration()
        {
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Publish(this);
        }
    }
}
