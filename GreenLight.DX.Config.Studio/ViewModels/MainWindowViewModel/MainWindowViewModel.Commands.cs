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
using GreenLight.DX.Config.Shared.Models;

namespace GreenLight.DX.Config.Studio.ViewModels
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
            OpenHermesCommand = new RelayCommand(ShowLogs);
            AddConfigurationCommand = new AsyncRelayCommand(OnAddConfiguration);
            SaveConfigurationsCommand = new AsyncRelayCommand(() => SaveConfigurationsToFile(null));
            WriteConfigClassesCommand = new AsyncRelayCommand(() => WriteAllConfigurations(null));
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


        private void ShowLogs()
        {
            _logger.ShowHermesWindow();
            Debug("Showing logs", "ShowLogs");
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
            Debug($"Writing configurations to {_configurationService.Root}", "WriteAllConfigurations");
            var busy = await _workflowDesignApi.BusyService.Begin("Writing configurations...");
            _configurationService.WriteClasses();
            await busy.DisposeAsync();
            Info("All configurations written", "WriteAllConfigurations");
            return;
        }

        private async Task OnAddConfiguration()
        {
            Debug("Adding new configuration", "OnAddConfiguration");
            try
            {
                var newConfig = new Configuration { Name = "New Configuration" };
                Model.Configurations.Add(newConfig); // Add to the Model
                Debug("New configuration added.", context: "OnAddConfiguration");
            }
            catch (Exception ex)
            {
                Error($"Error adding configuration: {ex.Message}", context: "OnAddConfiguration");
            }

        }

        public async Task SaveConfigurationsToFile(string? filePath = null)
        {
            if (_configurationService == null)
            {
                Warn("ConfigurationService is null", "SaveConfigurationsToFile");
                return;
            }
            if (_workflowDesignApi == null)
            {
                Warn("WorkflowDesignApi is null", "SaveConfigurationsToFile");
                return;
            }
            Debug("Saving configurations started.", context: "SaveConfigurationsToFile");
            var busy = await _workflowDesignApi.BusyService.Begin("Saving configurations...");
            _configurationService.SaveConfigurations();
            Info($"Configurations saved to '{filePath}'.", context: "SaveConfigurationsToFile");
            await busy.DisposeAsync();
            return;


        }


        public async Task<bool> LoadConfigurationFromFile()
        {
            if (_workflowDesignApi == null)
            {
                Warn("WorkflowDesignApi is null", "LoadConfigurationFromFile");
                return false;
            }
            if (_configurationService == null)
            {
                Warn("ConfigurationService is null", "LoadConfigurationFromFile");
                return false;
            }
            Debug($"Loading configurations from {_configurationService.Root}", "LoadConfigurationFromFile");
            var busy = await _workflowDesignApi.BusyService.Begin("Loading configurations...");

            Model = JsonConvert.DeserializeObject<Project>(await File.ReadAllTextAsync(filePath)) ?? throw new Exception("Could not deserialize model from file");
            InitializeModelEventHandlers();
            InitializeConfigurations();
            await busy.DisposeAsync();
            Debug($"Configurations loaded from '{filePath}'.", context: "LoadConfigurationFromFile");
            return true;



        }
    }
}
