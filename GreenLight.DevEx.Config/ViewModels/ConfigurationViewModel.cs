using GreenLight.DX.Commands;
using GreenLight.DX.Events;
using GreenLight.DX.Misc;
using GreenLight.DX.Models;
using GreenLight.DX.Windows;
using Prism.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GreenLight.DX.ViewModels
{
    public class ConfigurationViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Properties

        public ConfigurationModel Model { get; }

        public ObservableCollection<SettingRowViewModel> Settings { get; } = new ObservableCollection<SettingRowViewModel>();
        public ObservableCollection<AssetRowViewModel> Assets { get; } = new ObservableCollection<AssetRowViewModel>();
        public ObservableCollection<ResourceRowViewModel> Resources { get; } = new ObservableCollection<ResourceRowViewModel>();

        public string Name
        {
            get => Model.Name;
            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddSettingsRowCommand { get; set; }
        public ICommand AddAssetsRowCommand { get; set; }
        public ICommand AddResourcesRowCommand { get; set; }
        public ICommand EditConfigurationCommand { get; set; }
        public ICommand DeleteConfigurationCommand { get; set; }

        #endregion

        #region Constructors

        public ConfigurationViewModel(ConfigurationModel model, IEventAggregator eventAggregator)
        {
            Model = model;
            _eventAggregator = eventAggregator;
            Initialize();
        }

        public ConfigurationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Model = new ConfigurationModel();
            Initialize();
        }

        public ConfigurationViewModel()
        {
            _eventAggregator = new EventAggregator();
            Model = new ConfigurationModel();
            Initialize();
        }

        #endregion

        #region Initialization

        private void Initialize()
        {
            // Initialize the ViewModel collections from the Model
            foreach (var setting in Model.Settings)
            {
                Settings.Add(new SettingRowViewModel(_eventAggregator, setting, OnRowPropertyChanged));
            }
            foreach (var asset in Model.Assets)
            {
                Assets.Add(new AssetRowViewModel(_eventAggregator, asset, OnRowPropertyChanged));
            }
            foreach (var resource in Model.Resources)
            {
                Resources.Add(new ResourceRowViewModel(_eventAggregator, resource, OnRowPropertyChanged));
            }

            // Subscribe to changes in the Model's collections
            Model.Settings.CollectionChanged += Model_Settings_CollectionChanged;
            Model.Assets.CollectionChanged += Model_Assets_CollectionChanged;
            Model.Resources.CollectionChanged += Model_Resources_CollectionChanged;

            // Initialize Commands
            DeleteConfigurationCommand = new RelayCommand(OnDeleteConfiguration);
            AddSettingsRowCommand = new RelayCommand(OnSettingRowAdded);
            AddAssetsRowCommand = new RelayCommand(OnAssetRowAdded);
            AddResourcesRowCommand = new RelayCommand(OnResourceRowAdded);
            EditConfigurationCommand = new RelayCommand(OnEditConfiguration);

            // Subscribe to events
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<SettingRowModel>>().Subscribe(OnConfigurationRowDeleted);

            ValidateUniqueKeys();
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
                            Settings.Add(new SettingRowViewModel(_eventAggregator, newItem, OnRowPropertyChanged));
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
                        Settings.Add(new SettingRowViewModel(_eventAggregator, setting, OnRowPropertyChanged));
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
                            Assets.Add(new AssetRowViewModel(_eventAggregator, newItem, OnRowPropertyChanged));
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (AssetRowModel oldItem in e.OldItems)
                        {
                            Assets.Remove(Assets.FirstOrDefault(x => x.Model == oldItem));
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
                        Assets.Add(new AssetRowViewModel(_eventAggregator, asset, OnRowPropertyChanged));
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
                            Resources.Add(new ResourceRowViewModel(_eventAggregator, newItem, OnRowPropertyChanged));
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
                        Resources.Add(new ResourceRowViewModel(_eventAggregator, resource, OnRowPropertyChanged));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        #endregion

        #region Command Handlers

        private void OnSettingRowAdded()
        {
            var newSetting = new SettingRowModel(); // Create a new Model instance
            Model.Settings.Add(newSetting); // Add it directly to the Model
        }

        private void OnAssetRowAdded()
        {
            var newAsset = new AssetRowModel();
            Model.Assets.Add(newAsset);
        }

        private void OnResourceRowAdded()
        {
            var newResource = new ResourceRowModel();
            Model.Resources.Add(newResource);
        }

        private void OnConfigurationRowDeleted<T>(ConfigurationRowViewModel<T> rowViewModel) where T : ConfigurationRowModel
        {
            if (rowViewModel != null)
            {
                if (rowViewModel is SettingRowViewModel model) Model.Settings.Remove(model.Model);
                if (rowViewModel is AssetRowViewModel model1) Model.Assets.Remove(model1.Model);
                if (rowViewModel is ResourceRowViewModel model2) Model.Resources.Remove(model2.Model);
            }
        }

        private void OnEditConfiguration()
        {
            var editorWindow = new ConfigurationWindow(this);
            editorWindow.Show();
        }

        private void OnDeleteConfiguration()
        {
            _eventAggregator.GetEvent<ConfigurationDeletedEvent>().Publish(this);
        }

        #endregion

        #region Validation

        private void ValidateUniqueKeys()
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

        private void OnRowPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SettingRowViewModel.Key)
                || e.PropertyName == nameof(AssetRowViewModel.Key)
                || e.PropertyName == nameof(ResourceRowViewModel.Key)) 
                ValidateUniqueKeys();
        }

        #endregion
    }
}
