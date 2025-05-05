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
            DeleteConfigurationCommand = new AsyncRelayCommand(OnDeleteConfiguration);
            AddSettingsRowCommand = new AsyncRelayCommand(OnSettingRowAdded);
            AddAssetsRowCommand = new AsyncRelayCommand(OnAssetRowAdded);
            AddResourcesRowCommand = new AsyncRelayCommand(OnResourceRowAdded);
        }
        public async Task OnSettingRowAdded()
        {
            var newSetting = new SettingItemModel(); // Create a new Model instance
            Model.Settings.Add(newSetting); // Add it directly to the Model
        }

        public async Task OnAssetRowAdded()
        {
            var newAsset = new AssetItemModel();
            Model.Assets.Add(newAsset);
        }

        public async Task OnResourceRowAdded()
        {
            var newResource = new ResourceItemModel();
            Model.Resources.Add(newResource);
        }

        public async Task OnDeleteConfiguration()
        {
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Publish(this);
        }
    }
}
