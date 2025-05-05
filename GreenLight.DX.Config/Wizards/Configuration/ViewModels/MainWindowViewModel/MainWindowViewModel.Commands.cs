using GreenLight.DX.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using UiPath.Studio.Activities.Api;
using Microsoft.Win32;
using GreenLight.DX.Config.Services.Configuration.Models;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel
    {
        public Action? CloseWindowAction { get; set; }

        public ICommand AddConfigurationCommand { get; set; }
        public ICommand SaveConfigurationsCommand { get; set; }
        public ICommand LoadConfigurationsCommand { get; set; }
        public ICommand WriteConfigClassesCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadAssetsCommand { get; set; }
        public ICommand OpenAboutCommand { get; set; } = new AsyncRelayCommand(OpenAbout);

        public ICommand OpenHermesCommand { get; set; }

        public void InitializeCommands()
        {
            OpenHermesCommand = new RelayCommand(Show// Logs);
            AddConfigurationCommand = new AsyncRelayCommand(OnAddConfiguration);
            SaveConfigurationsCommand = new AsyncRelayCommand(() => SaveConfigurationsToFile());
            WriteConfigClassesCommand = new AsyncRelayCommand(() => WriteAllConfigurations());
            ExitCommand = new AsyncRelayCommand(OnExit);
            LoadAssetsCommand = new AsyncRelayCommand(LoadAssets); // In StudioApi.cs
            LoadConfigurationsCommand = new AsyncRelayCommand(() => LoadConfigurationFromFile());
        }
        public static async Task OpenAbout()
        {
            var url = "https://www.greenlightconsulting.com";
            try
            {
                // More robust way to handle the URL and potential errors:
                if (Uri.TryCreate(url, UriKind.Absolute, out var uri)) // Check if the URL is valid
                {
                    Process.Start(new ProcessStartInfo(uri.ToString()) { UseShellExecute = true });
                }
                else
                {
                    // Handle invalid URL (e.g., show an error message)
                    MessageBox.Show("Invalid URL.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., show an error message)
                MessageBox.Show($"Error opening webpage: {ex.Message}");
            }
        }


        private void Show// Logs()
        {
            _logger.ShowHermesWindow();
            Debug("Showing logs", "Show// Logs");
        }
        private async Task OnExit()
        {
            CloseWindowAction?.Invoke();
            Debug("Exiting", "OnExit");
        }
        private async Task WriteAllConfigurations()
        {
            if (_configurationService == null)
            {
                Warn("ConfigurationService is null", "WriteAllConfigurations");
                return;
            }
            if (_workflowDesignApi == null)
            {
                Warn("WorkflowDesignApi is null", "WriteAllConfigurations");
                return;
            }
            Debug($"Writing configurations to {_configurationService.ConfigurationsFile}", "WriteAllConfigurations");
            var busy = await _workflowDesignApi.BusyService.Begin("Writing configurations...");
            await _configurationService.WriteClasses();
            await busy.DisposeAsync();
            Info("All configurations written", "WriteAllConfigurations");
            return;
        }

        private async Task OnAddConfiguration()
        {
            Debug("Adding new configuration", "OnAddConfiguration");
            try
            {
                var newConfig = new ConfigurationModel { Name = "New Configuration" };
                _configurationService.Project.Configurations.Add(newConfig); // Add to the Model
                Debug("New configuration added.", context: "OnAddConfiguration");
            }
            catch (Exception ex)
            {
                Error($"Error adding configuration: {ex.Message}", context: "OnAddConfiguration");
            }

        }

        public async Task SaveConfigurationsToFile()
        {
            Debug("Saving configurations started.", context: "SaveConfigurationsToFile");
            await _configurationService.SaveConfigurations();
            Info($"Configurations saved to '{_configurationService.ConfigurationsFile}'.", context: "SaveConfigurationsToFile");
            return;


        }


        public async Task<bool> LoadConfigurationFromFile()
        {
            
            Debug($"Loading configurations from {_configurationService.ConfigurationsFile}", "LoadConfigurationFromFile");
            await _configurationService.ReadConfigurations();
            InitializeModelEventHandlers();
            InitializeConfigurations();
            Debug($"Configurations loaded from '{_configurationService.ConfigurationsFile}'.", context: "LoadConfigurationFromFile");
            return true;
        }
    }
}
