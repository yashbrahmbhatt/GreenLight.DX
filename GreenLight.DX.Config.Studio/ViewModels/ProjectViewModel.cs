using GreenLight.DX.Config.Studio.Commands;
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

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;
        private ConfigurationViewModel _selectedConfig;

        #endregion

        #region Properties
        public IWorkflowDesignApi? WorkflowDesignApi { get; set; }
        public Dictionary<string, IEnumerable<string>> OrchestratorAssets { get; set; } = new Dictionary<string, IEnumerable<string>>()
        {
            {"Folder", new List<string>() { "Asset1", "Asset2" } },
            {"Folder2", new List<string>() { "Asset3", "Asset4" } }
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

        public ICommand AddConfigurationCommand { get; set; }
        public ICommand SaveConfigurationsCommand { get; set; }
        public ICommand LoadConfigurationsCommand { get; set; }
        public ICommand WriteConfigClassesCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadAssetsCommand { get; set; }
        public ICommand OpenAboutCommand { get; set; } = new AsyncRelayCommand(OpenAbout);

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

        #region Constructors


        public ProjectViewModel(ProjectModel project, IWorkflowDesignApi workflowDesignApi)
        {
            _eventAggregator = new EventAggregator();
            Model = project;
            WorkflowDesignApi = workflowDesignApi;
            Initialize();
        }
        public ProjectViewModel(ProjectModel project)
        {
            _eventAggregator = new EventAggregator();
            Model = project;
            Initialize();
        }

        public ProjectViewModel()
        {
            _eventAggregator = new EventAggregator();
            Model = new ProjectModel();
            Initialize();
        }

        #endregion

        #region Initialization

        private void Initialize()
        {
            // Initialize Configurations from the Model
            foreach (var config in Model.Configurations)
            {
                Configurations.Add(new ConfigurationViewModel(config, _eventAggregator));
            }

            // Subscribe to the ConfigurationDeletedEvent
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Subscribe(OnConfigurationDeleted);

            AddConfigurationCommand = new AsyncRelayCommand(OnAddConfiguration);
            SaveConfigurationsCommand = new AsyncRelayCommand(SaveConfigurationsToFile);
            WriteConfigClassesCommand = new AsyncRelayCommand(WriteAllConfigurations);
            ExitCommand = new AsyncRelayCommand(OnExit);
            LoadAssetsCommand = new AsyncRelayCommand(LoadAssets);
            LoadConfigurationsCommand = new AsyncRelayCommand(LoadConfigurationFromFile);

            // Subscribe to Model.Configurations changes
            Model.Configurations.CollectionChanged += Model_Configurations_CollectionChanged;
            if (Configurations.Any())
                SelectedConfig = Configurations[0];
            ValidateUniqueNames();
        }

        #endregion

        #region Collection Changed Handlers

        private void Model_Configurations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (ConfigurationModel newConfig in e.NewItems)
                        {
                            Configurations.Add(new ConfigurationViewModel(newConfig, _eventAggregator));
                            SelectedConfig = Configurations[Configurations.Count - 1];
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
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
                    Configurations.Clear();
                    foreach (var config in Model.Configurations)
                    {
                        Configurations.Add(new ConfigurationViewModel(config, _eventAggregator));
                    }
                    break;
            }
            ValidateUniqueNames();
        }

        #endregion

        #region Command Handlers
        private async Task OnExit()
        {
            CloseWindowAction?.Invoke();
        }
        private async Task WriteAllConfigurations()
        {
            foreach (var config in Configurations)
            {
                await WriteClass(config.Model);
            }
        }

        private async Task OnAddConfiguration()
        {
            var newConfig = new ConfigurationModel { Name = "New Configuration" };
            Model.Configurations.Add(newConfig); // Add to the Model
        }

        private void OnConfigurationDeleted(ConfigurationViewModel configToDelete)
        {
            Model.Configurations.Remove(configToDelete.Model); // Remove from Model
        }
        public async Task LoadAssets()
        {
            if (WorkflowDesignApi == null) return;
            var busy = await WorkflowDesignApi.BusyService.Begin("Loading assets...");
            var folders = (await WorkflowDesignApi.OrchestratorApiService.AssetApiService.GetAssetFolders(100)).ToList();
            await busy.SetStatus($"{folders.Count()} folders found");
            OrchestratorAssets = new Dictionary<string, IEnumerable<string>>();
            for (var i = 0; i < folders.Count; i++)
            {
                var folder = folders[i];
                await busy.SetStatus($"Loading assets in '{folder}' ({i + 1}/{folders.Count}). Total Assets Loaded: {OrchestratorAssets.Values.Aggregate(0, (acc, curr) => acc + curr.Count())}");
                var assets = await WorkflowDesignApi.OrchestratorApiService.AssetApiService.GetAssets(new AssetRequestParameters() { }, folder);
                OrchestratorAssets.Add(folder, assets);
            }
            await busy.DisposeAsync();
        }

        public async Task WriteClass(ConfigurationModel configuration)
        {
            if (WorkflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            if (Configurations.Count == 0)
            {
                throw new InvalidOperationException("No configurations");
            }

            var projectPath = WorkflowDesignApi.ProjectPropertiesService.GetProjectDirectory();

            var configFilePath = Path.Combine(projectPath, RelativeRoot, configuration.Name.Replace(" ", "") + "Config.cs");
            var configDir = Path.GetDirectoryName(configFilePath) ?? throw new Exception("Could not get config directory path");
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            try
            {
                await File.WriteAllTextAsync(configFilePath, Model.ToClassString(configuration));
            }
            catch (Exception ex)
            {
                throw new Exception("Could not save configurations to file", ex);
            }
        }

        public async Task<bool> CreateAsset()
        {
            if (WorkflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            var token = await WorkflowDesignApi.AccessProvider.GetAccessToken("OR.Assets.Write", false);
            return false;
        }


        public async Task SaveConfigurationsToFile()
        {
            if (WorkflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            var projectPath = WorkflowDesignApi.ProjectPropertiesService.GetProjectDirectory();
            var saveFilePath = Path.Combine(projectPath, RelativeRoot, "Configurations.json");
            var saveDir = Path.GetDirectoryName(saveFilePath) ?? throw new Exception("Could not get save directory path");
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            var json = JsonConvert.SerializeObject(Configurations, Formatting.Indented);
            try
            {
                await File.WriteAllTextAsync(saveFilePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not save configurations to file", ex);
            }
        }

        public async Task<bool> LoadConfigurationFromFile()
        {
            if (WorkflowDesignApi == null)
            {
                throw new InvalidOperationException("WorkflowDesignApi is null");
            }
            var projectPath = WorkflowDesignApi.ProjectPropertiesService.GetProjectDirectory();
            var loadFilePath = Path.Combine(projectPath, RelativeRoot, "Configurations.json");
            if (!File.Exists(loadFilePath))
            {
                return false;
            }
            try
            {
                Model = JsonConvert.DeserializeObject<ProjectModel>(await File.ReadAllTextAsync(loadFilePath)) ?? throw new Exception("Could not deserialize model from file");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
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

