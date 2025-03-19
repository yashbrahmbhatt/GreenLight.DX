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
        private async Task WriteAllConfigurations(string? folderPath = null)
        {
            Info("Writing all configurations", "WriteAllConfigurations");
            var busy = await _workflowDesignApi.BusyService.Begin("Writing configurations...");
            if (folderPath == null)
            {
                await busy.SetStatus("Select a folder to write configurations");
                var SaveFileDialog = new Microsoft.Win32.OpenFileDialog()
                {
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    FileName = "Select Folder",
                    Filter = "Folder|*.",
                };
                if (SaveFileDialog.ShowDialog() == true)
                {
                    folderPath = Path.GetDirectoryName(SaveFileDialog.FileName);
                }
                else
                {
                    Debug("Write dialog cancelled", "WriteAllConfigurations");
                    return;
                }
            }
            Debug($"Writing configurations to {folderPath}", "WriteAllConfigurations");
            foreach (var config in Configurations)
            {
                await busy.SetStatus($"Writing configuration '{config.Name}' {Configurations.IndexOf(config) + 1}/{Configurations.Count}");
                await WriteClass(config.Model, folderPath);
            }
            await busy.DisposeAsync();
            Info("All configurations written", "WriteAllConfigurations");

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



        

        public async Task WriteClass(Configuration configuration, string folderPath)
        {
            if (_workflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }

            try
            {
                var configFilePath = Path.Combine(folderPath, configuration.Name.Replace(" ", "") + "Config.cs");
                var configDir = Path.GetDirectoryName(configFilePath) ?? throw new Exception("Could not get config directory path");

                if (!Directory.Exists(configDir))
                {
                    Directory.CreateDirectory(configDir);
                }

                await File.WriteAllTextAsync(configFilePath, Model.ToClassString(configuration));
                Debug($"Configuration class written to '{configFilePath}'.", context: "WriteClass");

            }
            catch (Exception ex)
            {
                Error($"Error writing configuration class: {ex.Message}", context: "WriteClass");
            }
        }



        public async Task SaveConfigurationsToFile(string? filePath = null)
        {
            if (_workflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            var busy = await _workflowDesignApi.BusyService.Begin("Saving configurations...");
            Debug("Saving configurations started.", context: "SaveConfigurationsToFile");

            if (filePath == null)
            {
                var SaveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
                    DefaultExt = ".json",
                    FileName = "Configurations.json"
                };
                if (SaveFileDialog.ShowDialog() == true)
                {
                    filePath = SaveFileDialog.FileName;
                }
            }


            Debug($"Saving configurations to {filePath}", "SaveConfigurationsToFile");
            var json = JsonConvert.SerializeObject(Model, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Debug($"Configurations saved to '{filePath}'.", context: "SaveConfigurationsToFile");
            await busy.DisposeAsync();
            return;


        }


        public async Task<bool> LoadConfigurationFromFile(string? filePath = null)
        {
            var busy = await _workflowDesignApi.BusyService.Begin("Loading configurations...");
            try
            {
                Debug("Loading configurations started.", context: "LoadConfigurationFromFile");
                if (filePath == null)
                {
                    await busy.SetStatus("Select a configuration file to load");
                    var openDialog = new Microsoft.Win32.OpenFileDialog
                    {
                        Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
                        DefaultExt = ".json",
                        FileName = "Configurations.json"
                    };
                    if (openDialog.ShowDialog() == true)
                    {
                        filePath = openDialog.FileName;
                    }
                    else
                    {
                        Debug("Load dialog cancelled", "LoadConfigurationFromFile");
                        await busy.DisposeAsync();
                        return false;
                    }
                }

                Debug($"Loading configurations from {filePath}", "LoadConfigurationFromFile");
                Model = JsonConvert.DeserializeObject<Project>(await File.ReadAllTextAsync(filePath)) ?? throw new Exception("Could not deserialize model from file");
                InitializeModelEventHandlers();
                InitializeConfigurations();
                await busy.DisposeAsync();
                Debug($"Configurations loaded from '{filePath}'.", context: "LoadConfigurationFromFile");
                return true;


            }
            catch (Exception ex)
            {
                await busy.DisposeAsync();
                Error($"Error loading configurations: {ex.Message}", context: "LoadConfigurationFromFile");
                return false;
            }
        }
    }
}
