using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Shared.Commands;
using GreenLight.DX.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class ConfigurationViewModel
    {

        public ICommand AddSettingsRowCommand { get; set; }
        public ICommand AddAssetsRowCommand { get; set; }
        public ICommand AddResourcesRowCommand { get; set; }
        public ICommand EditConfigurationCommand { get; set; }
        public ICommand DeleteConfigurationCommand { get; set; }

        public void InitializeCommands()
        {
            DeleteConfigurationCommand = new AsyncRelayCommand(OnDeleteConfiguration);
            AddSettingsRowCommand = new AsyncRelayCommand(OnSettingRowAdded);
            AddAssetsRowCommand = new AsyncRelayCommand(OnAssetRowAdded);
            AddResourcesRowCommand = new AsyncRelayCommand(OnResourceRowAdded);
            EditConfigurationCommand = new AsyncRelayCommand(OnEditConfiguration);
        }
        public async Task OnSettingRowAdded()
        {
            var newSetting = new SettingItem(); // Create a new Model instance
            Model.Settings.Add(newSetting); // Add it directly to the Model
        }

        public async Task OnAssetRowAdded()
        {
            var newAsset = new AssetItem();
            Model.Assets.Add(newAsset);
        }

        public async Task OnResourceRowAdded()
        {
            var newResource = new ResourceItem();
            Model.Resources.Add(newResource);
        }

        public async Task OnEditConfiguration()
        {
            var editorWindow = new ConfigurationWindow(this);
            editorWindow.Show();
        }

        public async Task OnDeleteConfiguration()
        {
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Publish(this);
        }
    }
}
