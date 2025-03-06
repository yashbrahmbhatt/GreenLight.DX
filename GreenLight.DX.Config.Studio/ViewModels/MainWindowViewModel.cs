using Prism.Events;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Models;
using UiPath.Studio.Activities.Api;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Shared.Hermes.Models;
using GreenLight.DX.Shared.Hermes.Services;
using GreenLight.DX.Shared.Commands;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields
        private readonly IEventAggregator _eventAggregator;
        private ConfigurationViewModel _selectedConfig;
        private readonly IServiceProvider _services;
        private readonly IWorkflowDesignApi? _workflowDesignApi;
        private readonly IHermesService _logger;
        private static readonly string _logContext = nameof(MainWindowViewModel);
        #endregion

        #region Log Functions
        private void Info(string message, string context) => _logger.Log(message, $"{_logContext}.{context}", LogLevel.Info);
        private void Error(string message, string context) => _logger.Log(message, $"{_logContext}.{context}", LogLevel.Error);
        private void Warning(string message, string context) => _logger.Log(message, $"{_logContext}.{context}", LogLevel.Warning);
        private void Debug(string message, string context) => _logger.Log(message, $"{_logContext}.{context}", LogLevel.Debug);
        #endregion

        #region Properties
        public ObservableCollection<KeyValuePair<string, IEnumerable<string>>> AssetsMap { get; set; } = new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
        {
            new KeyValuePair<string, IEnumerable<string>>("Folder", new List<string> { "Asset1", "Asset2", "Asset3" }),
            new KeyValuePair<string, IEnumerable<string>>("Folder2", new List<string> { "Asset3", "Asset4", "Asset5" }),
            new KeyValuePair<string, IEnumerable<string>>("Folder3", new List<string> { "Asset6", "Asset7", "Asset8" })
        };
        public string RelativeRoot { get; set; } = "Configurations";
        public ProjectModel Model { get; set; }
        public string Namespace
        {
            get => Model.Namespace;
            set
            {
                if (Model.Namespace != value)
                {
                    Model.Namespace = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ConfigurationViewModel> Configurations { get; } = new ObservableCollection<ConfigurationViewModel>();

        public ConfigurationViewModel SelectedConfig
        {
            get => _selectedConfig;
            set
            {
                if (_selectedConfig != value)
                {
                    _selectedConfig = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        public ICommand AddConfigurationCommand { get; set; }
        public ICommand SaveConfigurationsCommand { get; set; }
        public ICommand LoadConfigurationsCommand { get; set; }
        public ICommand WriteConfigClassesCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadAssetsCommand { get; set; }
        public ICommand OpenAboutCommand { get; set; } = new AsyncRelayCommand(OpenAbout);

        public ICommand OpenHermesCommand { get; }

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

        public Action? CloseWindowAction { get; set; }

        #endregion

        #region Events
        public event EventHandler? Initialized;
        #endregion

        #region Constructors


        public MainWindowViewModel(IServiceProvider services, ProjectModel? model)
        {
            _services = services;
            model = model ?? new ProjectModel();
            Model = model;
            _eventAggregator = _services.GetRequiredService<IEventAggregator>();
            _workflowDesignApi = _services.GetRequiredService<IWorkflowDesignApi>();
            _logger = _services.GetRequiredService<IHermesService>();
            Info("Initializing MainWindowViewModel", "Constructor");


            // Subscribe to the ConfigurationDeletedEvent
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Subscribe(OnConfigurationDeleted);

            OpenHermesCommand = new RelayCommand(ShowLogs);
            AddConfigurationCommand = new AsyncRelayCommand(OnAddConfiguration);
            SaveConfigurationsCommand = new AsyncRelayCommand(SaveConfigurationsToFile);
            WriteConfigClassesCommand = new AsyncRelayCommand(WriteAllConfigurations);
            ExitCommand = new AsyncRelayCommand(OnExit);
            LoadAssetsCommand = new AsyncRelayCommand(LoadAssets);
            LoadConfigurationsCommand = new AsyncRelayCommand(LoadConfigurationFromFile);

            // Subscribe to Model.Configurations changes
            Model.Configurations.CollectionChanged += Model_Configurations_CollectionChanged;

            ValidateUniqueNames();
            Initialized += (sender, args) => InitializeConfigurations();
            Initialized?.Invoke(this, EventArgs.Empty);
            Info("MainWindowViewModel initialized", "Constructor");
        }
        public MainWindowViewModel() : this(
            new ServiceCollection().BuildServiceProvider(),
            new ProjectModel()
        )
        { }

        #endregion

        public void InitializeConfigurations()
        {
            // Initialize Configurations from the Model
            Info("Initializing configurations", "InitializeConfigurations");
            Configurations.Clear();
            foreach (var config in Model.Configurations)
            {
                Configurations.Add(new ConfigurationViewModel(_services, config, AssetsMap));
            }
            if (Configurations.Any())
                SelectedConfig = Configurations[0];

            Info("Configurations initialized", "InitializeConfigurations");
        }

        #region Collection Changed Handlers

        private void Model_Configurations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug("Model.Configurations collection changed", "Model_Configurations_CollectionChanged");
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Debug($"Adding {e.NewItems?.Count} new configurations", "Model_Configurations_CollectionChanged");
                    if (e.NewItems != null)
                    {
                        foreach (ConfigurationModel newConfig in e.NewItems)
                        {
                            Configurations.Add(new ConfigurationViewModel(_services, newConfig, AssetsMap));
                            SelectedConfig = Configurations[Configurations.Count - 1];
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Debug($"Removing {e.OldItems?.Count} configurations", "Model_Configurations_CollectionChanged");
                    if (e.OldItems != null)
                    {
                        foreach (ConfigurationModel oldConfig in e.OldItems)
                        {
                            Configurations.Remove(Configurations.FirstOrDefault(x => x.Model == oldConfig));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    Debug("Resetting configurations", "Model_Configurations_CollectionChanged");
                    Configurations.Clear();
                    foreach (var config in Model.Configurations)
                    {
                        Configurations.Add(new ConfigurationViewModel(_services, config, AssetsMap));
                    }
                    break;
            }
            ValidateUniqueNames();
            Debug("Model.Configurations collection changed handled", "Model_Configurations_CollectionChanged");
        }

        #endregion

        #region Command Handlers

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
            Info("Writing all configurations", "WriteAllConfigurations");
            foreach (var config in Configurations)
            {
                await WriteClass(config.Model);
            }
            Info("All configurations written", "WriteAllConfigurations");
        }

        private async Task OnAddConfiguration()
        {
            Debug("Adding new configuration", "OnAddConfiguration");
            try
            {
                var newConfig = new ConfigurationModel { Name = "New Configuration" };
                Model.Configurations.Add(newConfig); // Add to the Model
                Debug("New configuration added.", context: "OnAddConfiguration");
            }
            catch (Exception ex)
            {
                Error($"Error adding configuration: {ex.Message}", context: "OnAddConfiguration");
            }

        }

        private void OnConfigurationDeleted(ConfigurationViewModel configToDelete)
        {
            try
            {
                Model.Configurations.Remove(configToDelete.Model); // Remove from Model
                Debug($"Configuration '{configToDelete.Name}' deleted.", context: "OnConfigurationDeleted");
            }
            catch (Exception ex)
            {
                Error($"Error deleting configuration: {ex.Message}", context: "OnConfigurationDeleted");
            }
        }

        public async Task LoadAssets()
        {
            if (_workflowDesignApi == null) return;
            try
            {
                var busy = await _workflowDesignApi.BusyService.Begin("Loading assets...");
                Debug("Loading assets started.", context: "LoadAssets");

                var folders = (await _workflowDesignApi.OrchestratorApiService.AssetApiService.GetAssetFolders(100)).ToList();
                await busy.SetStatus($"{folders.Count} folders found");

                AssetsMap.Clear();
                for (var i = 0; i < folders.Count; i++)
                {
                    var folder = folders[i];
                    await busy.SetStatus($"Loading assets in '{folder}' ({i + 1}/{folders.Count}). Total Assets Loaded: {AssetsMap.Aggregate(0, (acc, curr) => acc + curr.Value.Count())}");
                    var assets = await _workflowDesignApi.OrchestratorApiService.AssetApiService.GetAssets(new AssetRequestParameters() { }, folder);
                    AssetsMap.Add(new KeyValuePair<string, IEnumerable<string>>(folder, assets));
                }
                await busy.DisposeAsync();
                Debug($"{AssetsMap.Aggregate(0, (acc, curr) => acc + curr.Value.Count())} assets loaded.", context: "LoadAssets");

            }
            catch (Exception ex)
            {
                Error($"Error loading assets: {ex.Message}", context: "LoadAssets");
            }
        }

        public async Task WriteClass(ConfigurationModel configuration)
        {
            if (_workflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }

            try
            {
                var projectPath = _workflowDesignApi.ProjectPropertiesService.GetProjectDirectory();
                var configFilePath = Path.Combine(projectPath, RelativeRoot, configuration.Name.Replace(" ", "") + "Config.cs");
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



        public async Task SaveConfigurationsToFile()
        {
            if (_workflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            try
            {
                var busy = await _workflowDesignApi.BusyService.Begin("Saving configurations...");
                Debug("Saving configurations started.", context: "SaveConfigurationsToFile");


                var SaveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
                    DefaultExt = ".json",
                    FileName = "Configurations.json"
                };
                if(SaveFileDialog.ShowDialog() != true)
                {
                    var saveFilePath = SaveFileDialog.FileName;
                    Debug($"Saving configurations to {saveFilePath}", "SaveConfigurationsToFile");
                    var json = JsonConvert.SerializeObject(Model, Formatting.Indented);
                    await File.WriteAllTextAsync(saveFilePath, json);
                    Debug($"Configurations saved to '{saveFilePath}'.", context: "SaveConfigurationsToFile");
                    return;
                }

                await busy.DisposeAsync();
            }
            catch (Exception ex)
            {
                Error($"Error saving configurations: {ex.Message}", context: "SaveConfigurationsToFile");
            }
        }

        public async Task<bool> LoadConfigurationFromFile()
        {
            if (_workflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            var busy = await _workflowDesignApi.BusyService.Begin("Loading configurations...");
            try
            {
                Debug("Loading configurations started.", context: "LoadConfigurationFromFile");

                var projectPath = _workflowDesignApi.ProjectPropertiesService.GetProjectDirectory();
                var loadFilePath = Path.Combine(projectPath, RelativeRoot, "Configurations.json");

                if (!File.Exists(loadFilePath))
                {
                    await busy.DisposeAsync();
                    Warning($"No configuration file found at '{loadFilePath}'.", context: "LoadConfigurationFromFile");
                    return false;
                }

                Model = JsonConvert.DeserializeObject<ProjectModel>(await File.ReadAllTextAsync(loadFilePath)) ?? throw new Exception("Could not deserialize model from file");
                await busy.DisposeAsync();
                Debug($"Configurations loaded from '{loadFilePath}'.", context: "LoadConfigurationFromFile");
                return true;
            }
            catch (Exception ex)
            {
                await busy.DisposeAsync();
                Error($"Error loading configurations: {ex.Message}", context: "LoadConfigurationFromFile");
                return false;
            }
        }
        #endregion

        #region Validation

        private void ValidateUniqueNames()
        {
            var duplicateNames = Configurations
                .GroupBy(c => c.Model.Name)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            Debug("Validating unique configuration names", "ValidateUniqueNames");
            foreach (var config in Configurations)
            {
                if (duplicateNames.Contains(config.Name))
                {
                    config.AddError(nameof(config.Name), $"Duplicate configuration name");
                }
                else
                {
                    config.RemoveError(nameof(config.Name), $"Duplicate configuration name");
                }
            }
            
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ValidateUniqueNames();
        }

        #endregion

        #region INotifyDataErrorInfo Implementation
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errors.Count != 0;
        public void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }
            _errors[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors[propertyName].Remove(error);
                if (_errors[propertyName].Count == 0)
                {
                    _errors.Remove(propertyName);
                }
                OnErrorsChanged(propertyName);
            }
        }
        public IEnumerable GetErrors(string? propertyName)
        {
            if (ErrorsChanged != null || !_errors.ContainsKey(propertyName)) return Enumerable.Empty<string>();
            return _errors[propertyName];
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));

        }
        #endregion
    }
}

