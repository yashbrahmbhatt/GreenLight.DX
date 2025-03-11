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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IServiceProvider _services;
        private readonly IWorkflowDesignApi? _workflowDesignApi;
        private readonly IHermesService? _logger;
        private static readonly string _logContext = nameof(MainWindowViewModel);
        #endregion

        #region Log Functions
        private void Info(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Info);
        private void Error(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Error);
        private void Warning(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Warning);
        private void Debug(string message, string context) => _logger?.Log(message, $"{_logContext}.{context}", LogLevel.Debug);
        #endregion

        #region Properties
        public ObservableCollection<KeyValuePair<string, IEnumerable<string>>> AssetsMap { get; set; } = new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>() { };
        private ProjectModel _model;
        public ProjectModel Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }
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

        private ConfigurationViewModel _selectedConfig;

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
            SaveConfigurationsCommand = new AsyncRelayCommand(() => SaveConfigurationsToFile(null));
            WriteConfigClassesCommand = new AsyncRelayCommand(() => WriteAllConfigurations(null));
            ExitCommand = new AsyncRelayCommand(OnExit);
            LoadAssetsCommand = new AsyncRelayCommand(LoadAssets);
            LoadConfigurationsCommand = new AsyncRelayCommand(() => LoadConfigurationFromFile());

            // Subscribe to Model.Configurations changes
            Model.Configurations.CollectionChanged += Model_Configurations_CollectionChanged;
            ValidateUniqueNames();
            LoadAssets().Await();
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
        private async Task WriteAllConfigurations(string? folderPath = null)
        {
            Info("Writing all configurations", "WriteAllConfigurations");
            var busy = await _workflowDesignApi.BusyService.Begin("Writing configurations...");
            if (folderPath == null)
            {
                busy.SetStatus("Select a folder to write configurations");
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
                await WriteClass(config.Model, folderPath);
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

        public void OnConfigurationDeleted(ConfigurationViewModel configToDelete)
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
                OnPropertyChanged(nameof(AssetsMap));
                await busy.DisposeAsync();
                Debug($"{AssetsMap.Aggregate(0, (acc, curr) => acc + curr.Value.Count())} assets loaded.", context: "LoadAssets");

            }
            catch (Exception ex)
            {
                Error($"Error loading assets: {ex.Message}", context: "LoadAssets");
            }
        }

        public async Task WriteClass(ConfigurationModel configuration, string folderPath)
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
            if (_workflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
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
                Model = JsonConvert.DeserializeObject<ProjectModel>(await File.ReadAllTextAsync(filePath)) ?? throw new Exception("Could not deserialize model from file");
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
    }
}

