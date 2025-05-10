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
        public ICommand OpenAboutCommand { get; set; }

        public ICommand OpenHermesCommand { get; set; }

        public void InitializeCommands()
        {
            Debug("Initializing commands", nameof(InitializeCommands));

            OpenHermesCommand = new RelayCommand(ShowLogs);
            AddConfigurationCommand = new RelayCommand(OnAddConfiguration);
            SaveConfigurationsCommand = new RelayCommand(() => SaveConfigurationsToFile());
            WriteConfigClassesCommand = new RelayCommand(() => WriteAllConfigurations());
            ExitCommand = new RelayCommand(OnExit);
            LoadAssetsCommand = new RelayCommand(LoadAssets);
            LoadConfigurationsCommand = new RelayCommand(() => LoadConfigurationFromFile());
            OpenAboutCommand = new RelayCommand(OpenAbout);

            Debug("Commands initialized", nameof(InitializeCommands));
        }

        public void OpenAbout()
        {
            Debug("Opening About page", nameof(OpenAbout));
            var url = "https://www.greenlightconsulting.com";
            try
            {
                if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
                {
                    Process.Start(new ProcessStartInfo(uri.ToString()) { UseShellExecute = true });
                    Debug($"Opened URL: {uri}", nameof(OpenAbout));
                }
                else
                {
                    Error($"Invalid URL format: {url}", nameof(OpenAbout));
                }
            }
            catch (Exception ex)
            {
                Error($"Error opening webpage: {ex.Message}", nameof(OpenAbout));
            }
            Debug("Finished Opening About page", nameof(OpenAbout));
        }

        private void ShowLogs()
        {
            Debug("Showing logs window", nameof(ShowLogs));
            _logger.ShowHermesWindow();
            Debug("Logs window shown", nameof(ShowLogs));
        }

        private void OnExit()
        {
            Debug("Executing Exit command", nameof(OnExit));
            CloseWindowAction?.Invoke();
            Debug("Close window action invoked", nameof(OnExit));
        }

        private void WriteAllConfigurations()
        {
            Debug("Writing configurations to classes", nameof(WriteAllConfigurations));

            if (_configurationService == null)
            {
                Error("ConfigurationService is null. Cannot write configurations.", nameof(WriteAllConfigurations));
                return;
            }
            try
            {
                _configurationService.WriteClasses();
                Info("Configurations written successfully", nameof(WriteAllConfigurations));
            }
            catch (Exception ex)
            {
                Error($"Error writing configurations: {ex.Message}", nameof(WriteAllConfigurations));
            }
            Debug("Finished writing configurations to classes", nameof(WriteAllConfigurations));
        }

        private void OnAddConfiguration()
        {
            Debug("Adding new configuration", nameof(OnAddConfiguration));
            try
            {
                var newConfig = new ConfigurationModel { Name = "New Configuration" };
                if (_configurationService?.Project?.Configurations != null)
                {
                    _configurationService.Project.Configurations.Add(newConfig);
                    Debug("New configuration added to collection", nameof(OnAddConfiguration));
                }
                else
                {
                    Error("Cannot add configuration: ConfigurationService or Project or Configurations is null.", nameof(OnAddConfiguration));
                }
            }
            catch (Exception ex)
            {
                Error($"Error adding configuration: {ex.Message}", nameof(OnAddConfiguration));
            }
            Debug("Finished adding new configuration", nameof(OnAddConfiguration));
        }

        public void SaveConfigurationsToFile()
        {
            Debug("Saving configurations to file", nameof(SaveConfigurationsToFile));
            if (_configurationService == null)
            {
                Error("ConfigurationService is null. Cannot save configurations.", nameof(SaveConfigurationsToFile));
                return;
            }
            try
            {
                _configurationService.SaveConfigurations();
                Info("Configurations saved successfully", nameof(SaveConfigurationsToFile));
            }
            catch (Exception ex)
            {
                Error($"Error saving configurations: {ex.Message}", nameof(SaveConfigurationsToFile));
            }
            Debug("Finished saving configurations to file", nameof(SaveConfigurationsToFile));
        }

        public bool LoadConfigurationFromFile()
        {
            Debug("Loading configurations from file", nameof(LoadConfigurationFromFile));
            bool success = false;

            if (_configurationService == null)
            {
                Error("ConfigurationService is null. Cannot load configurations.", nameof(LoadConfigurationFromFile));
                return false;
            }

            try
            {
                _configurationService.ReadConfigurations();
                Debug("Configurations read from file", nameof(LoadConfigurationFromFile));
                InitializeModelEventHandlers();
                InitializeConfigurations();
                Info("Configurations loaded successfully", nameof(LoadConfigurationFromFile));
                success = true;
            }
            catch (FileNotFoundException ex)
            {
                Error($"Configuration file not found: {_configurationService.ConfigurationsFile}. {ex.Message}", nameof(LoadConfigurationFromFile));
            }
            catch (Exception ex)
            {
                Error($"Error loading configurations: {ex.Message}", nameof(LoadConfigurationFromFile));
            }

            Debug($"Finished loading configurations from file. Success: {success}", nameof(LoadConfigurationFromFile));
            return success;
        }
    }
}
