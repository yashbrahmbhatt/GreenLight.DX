using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Models;
using GreenLight.DX.Windows;
using Prism.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Shared.Commands;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class ConfigurationViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IServiceProvider _services;

        #endregion

        #region Properties
        public ObservableCollection<KeyValuePair<string, IEnumerable<string>>> AssetsMap { get; }
        public ConfigurationModel Model { get; }

        public ObservableCollection<SettingRowViewModel> Settings { get; } = new ObservableCollection<SettingRowViewModel>();
        public ObservableCollection<AssetRowViewModel> Assets { get; } = new ObservableCollection<AssetRowViewModel>();
        public ObservableCollection<ResourceRowViewModel> Resources { get; } = new ObservableCollection<ResourceRowViewModel>();

        public ObservableCollection<string> FolderNames { get; } = new ObservableCollection<string>();

        [Required(ErrorMessage = "A class name is required for the entire configuration")]
        public string Name
        {
            get => Model.Name;
            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                    ValidateRequired(value, nameof(Name));
                    OnPropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "A description is required for the entire configuration")]
        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    ValidateRequired(value, nameof(Description));
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        public ICommand AddSettingsRowCommand { get; set; }
        public ICommand AddAssetsRowCommand { get; set; }
        public ICommand AddResourcesRowCommand { get; set; }
        public ICommand EditConfigurationCommand { get; set; }
        public ICommand DeleteConfigurationCommand { get; set; }

        #endregion

        #region Constructors

        public ConfigurationViewModel(IServiceProvider services, ConfigurationModel model, ObservableCollection<KeyValuePair<string, IEnumerable<string>>> assetsMap)
        {
            _services = services;
            Model = model;
            _eventAggregator = services.GetRequiredService<IEventAggregator>();
            AssetsMap = assetsMap;
            AssetsMap.CollectionChanged += AssetsMap_CollectionChanged;

            // Initialize Commands
            DeleteConfigurationCommand = new AsyncRelayCommand(OnDeleteConfiguration);
            AddSettingsRowCommand = new AsyncRelayCommand(OnSettingRowAdded);
            AddAssetsRowCommand = new AsyncRelayCommand(OnAssetRowAdded);
            AddResourcesRowCommand = new AsyncRelayCommand(OnResourceRowAdded);
            EditConfigurationCommand = new AsyncRelayCommand(OnEditConfiguration);

            // Subscribe to changes in the Model's collections
            Model.Settings.CollectionChanged += Model_Settings_CollectionChanged;
            Model.Assets.CollectionChanged += Model_Assets_CollectionChanged;
            Model.Resources.CollectionChanged += Model_Resources_CollectionChanged;

            // Subscribe to events
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<SettingRowModel>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<AssetRowModel>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<ResourceRowModel>>().Subscribe(OnConfigurationRowDeleted);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<SettingRowModel>>().Subscribe(OnRowPropertyChange);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<AssetRowModel>>().Subscribe(OnRowPropertyChange);
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceRowModel>>().Subscribe(OnRowPropertyChange);
            InitializeRows();
            InitializeAssetFolders();
            ValidateUniqueKeys();

        }

        public ConfigurationViewModel() : this(
            new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider(),
            new ConfigurationModel(),
            new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
            {
                new KeyValuePair<string, IEnumerable<string>>("Folder", new List<string>(){"Asset1", "Asset2", "Asset3"}),
                new KeyValuePair<string, IEnumerable<string>>( "Folder2", new List<string>(){"Asset4", "Asset5", "Asset6"}),
                new KeyValuePair<string, IEnumerable<string>>( "Folder3", new List<string>(){"Asset7", "Asset8", "Asset9"})
            }
        )
        { }

        #endregion

        #region Initialization


        private void InitializeRows()
        {
            // Initialize the ViewModel collections from the Model
            foreach (var setting in Model.Settings)
            {
                Settings.Add(new SettingRowViewModel(_services, setting, Model.Settings.IndexOf(setting) + 1));
            }
            foreach (var asset in Model.Assets)
            {
                Assets.Add(new AssetRowViewModel(_services, asset, Model.Assets.IndexOf(asset) + 1, AssetsMap));
            }
            foreach (var resource in Model.Resources)
            {
                Resources.Add(new ResourceRowViewModel(_services, resource, Model.Resources.IndexOf(resource) + 1));
            }
        }

        private void InitializeAssetFolders()
        {
            FolderNames.Clear();
            foreach (var kvp in AssetsMap)
            {
                FolderNames.Add(kvp.Key);
            }
            OnPropertyChanged(nameof(FolderNames));
        }

        #endregion

        #region Collection Changed Handlers

        private void Model_Settings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (SettingRowModel newItem in e.NewItems)
                        {
                            Settings.Add(new SettingRowViewModel(_services, newItem, Settings.Count + 1));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (SettingRowModel oldItem in e.OldItems)
                        {
                            Settings.Remove(Settings.FirstOrDefault(x => x.Model == oldItem));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    Settings.Clear();
                    foreach (var setting in Model.Settings)
                    {
                        Settings.Add(new SettingRowViewModel(_services, setting, Settings.Count + 1));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        private void Model_Assets_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (AssetRowModel newItem in e.NewItems)
                        {
                            Assets.Add(new AssetRowViewModel(_services, newItem, Assets.Count + 1, AssetsMap));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (AssetRowModel oldItem in e.OldItems)
                        {
                            Assets.Remove(Assets.First(x => x.Model == oldItem));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    Assets.Clear();
                    foreach (var asset in Model.Assets)
                    {
                        Assets.Add(new AssetRowViewModel(_services, asset, Assets.Count + 1, AssetsMap));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        private void Model_Resources_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (ResourceRowModel newItem in e.NewItems)
                        {
                            Resources.Add(new ResourceRowViewModel(_services, newItem, Resources.Count + 1));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (ResourceRowModel oldItem in e.OldItems)
                        {
                            Resources.Remove(Resources.FirstOrDefault(x => x.Model == oldItem));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    Resources.Clear();
                    foreach (var resource in Model.Resources)
                    {
                        Resources.Add(new ResourceRowViewModel(_services, resource, Resources.Count + 1));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        public void AssetsMap_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender != null)
            {
                var map = (ObservableCollection<KeyValuePair<string, IEnumerable<string>>>)sender;
                FolderNames.Clear();
                foreach (var kvp in map)
                {
                    FolderNames.Add(kvp.Key);
                }
            }
        }

        #endregion

        #region Command Handlers

        public async Task OnSettingRowAdded()
        {
            var newSetting = new SettingRowModel(); // Create a new Model instance
            Model.Settings.Add(newSetting); // Add it directly to the Model
        }

        public async Task OnAssetRowAdded()
        {
            var newAsset = new AssetRowModel();
            Model.Assets.Add(newAsset);
        }

        public async Task OnResourceRowAdded()
        {
            var newResource = new ResourceRowModel();
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

        #endregion

        #region Validation

        public void ValidateUniqueKeys()
        {
            var allKeys = Settings.Select(s => s.Key)
                .Concat(Assets.Select(a => a.Key))
                .Concat(Resources.Select(r => r.Key));

            var duplicateKeys = allKeys.GroupBy(k => k)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (var setting in Settings) setting.RemoveError(nameof(setting.Key), $"Duplicate key");
            foreach (var asset in Assets) asset.RemoveError(nameof(asset.Key), $"Duplicate key");
            foreach (var resource in Resources) resource.RemoveError(nameof(resource.Key), $"Duplicate key");

            foreach (var key in duplicateKeys)
            {
                // Add error to relevant view models
                var settings = Settings.Where(s => s.Key == key);
                if (settings.Any())
                    foreach (var setting in settings) setting.AddError(nameof(setting.Key), $"Duplicate key");

                var assets = Assets.Where(a => a.Key == key);
                if (assets.Any())
                    foreach (var asset in assets) asset.AddError(nameof(asset.Key), $"Duplicate key");

                var resources = Resources.Where(r => r.Key == key);
                if (resources.Any())
                    foreach (var resource in resources) resource.AddError(nameof(resource.Key), $"Duplicate key");
            }
        }

        protected void ValidateRequired(object value, string propertyName)
        {
            var message = Studio.Resources.ValidationMessages.Property_Required.Replace("{PropertyName}", propertyName);
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                AddError(propertyName, message);
            }
            else
            {
                RemoveError(propertyName, message);
            }
            OnPropertyChanged(nameof(HasErrors));
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        #region Event Handlers

        public void OnRowPropertyChange<T>(ConfigurationRowPropertyChangedEventArgs<T> rowViewModel) where T : ConfigurationRowModel
        {
            ValidateUniqueKeys();
        }

        public void OnConfigurationRowDeleted<T>(ConfigurationRowViewModel<T> rowViewModel) where T : ConfigurationRowModel
        {
            if (rowViewModel != null)
            {
                if (rowViewModel is SettingRowViewModel model) Model.Settings.Remove(model.Model);
                if (rowViewModel is AssetRowViewModel model1) Model.Assets.Remove(model1.Model);
                if (rowViewModel is ResourceRowViewModel model2) Model.Resources.Remove(model2.Model);
            }
        }
        #endregion
    }
}
