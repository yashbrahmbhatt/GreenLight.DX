using GreenLight.DX.Commands;
using GreenLight.DX.Events;
using GreenLight.DX.Misc;
using GreenLight.DX.Models;
using GreenLight.DX.Windows;
using Prism.Events; // Add this using statement
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
        public ConfigurationModel Model { get; }

        private readonly IEventAggregator _eventAggregator;

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

        public void Initialize()
        {
            // Initialize the ViewModel collections from the Model
            foreach (var setting in Model.Settings)
            {
                var vm = new SettingRowViewModel(_eventAggregator, setting);
                vm.PropertyChanged += OnRowPropertyChanged;
                Settings.Add(vm);
            }
            foreach (var asset in Model.Assets)
            {
                var vm = new AssetRowViewModel(_eventAggregator, asset);
                vm.PropertyChanged += OnRowPropertyChanged;
                Assets.Add(new AssetRowViewModel(_eventAggregator, asset));
            }
            foreach (var resource in Model.Resources)
            {
                var vm = new ResourceRowViewModel(_eventAggregator, resource);
                vm.PropertyChanged += OnRowPropertyChanged;
                Resources.Add(new ResourceRowViewModel(_eventAggregator, resource));
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
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent>().Subscribe(OnConfigurationRowDeleted);

            ValidateUniqueKeys();
        }

        private void Model_Settings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (SettingRowModel newItem in e.NewItems)
                        {
                            var vm = new SettingRowViewModel(_eventAggregator, newItem);
                            vm.PropertyChanged += OnRowPropertyChanged;
                            Settings.Add(vm);
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
                        var vm = new SettingRowViewModel(_eventAggregator, setting);
                        vm.PropertyChanged += OnRowPropertyChanged;
                        Settings.Add(vm);
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
                            var vm = new AssetRowViewModel(_eventAggregator, newItem);
                            vm.PropertyChanged += OnRowPropertyChanged;
                            Assets.Add(vm);
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
                        var vm = new AssetRowViewModel(_eventAggregator, asset);
                        vm.PropertyChanged += OnRowPropertyChanged;
                        Assets.Add(vm);
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
                            var vm = new ResourceRowViewModel(_eventAggregator, newItem);
                            vm.PropertyChanged += OnRowPropertyChanged;
                            Resources.Add(vm);
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
                        var vm = new ResourceRowViewModel(_eventAggregator, resource);
                        vm.PropertyChanged += OnRowPropertyChanged;
                        Resources.Add(vm);
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        private void OnRowPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Property Changed: {sender}");
            ClearRowErrors((ConfigurationRowViewModel)sender);
            ValidateUniqueKeys();
        }
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

        private void OnConfigurationRowDeleted(ConfigurationRowViewModel rowViewModel)
        {
            if (rowViewModel != null)
            {
                if (rowViewModel is SettingRowViewModel) Model.Settings.Remove(((SettingRowViewModel)rowViewModel).Model);
                if (rowViewModel is AssetRowViewModel) Model.Assets.Remove(((AssetRowViewModel)rowViewModel).Model);
                if (rowViewModel is ResourceRowViewModel) Model.Resources.Remove(((ResourceRowViewModel)rowViewModel).Model);
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

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ValidateUniqueKeys()
        {
            var allKeys = Settings.Select(s => s.Key)
                .Concat(Assets.Select(a => a.Key))
                .Concat(Resources.Select(r => r.Key));

            var duplicateKeys = allKeys.GroupBy(k => k)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (var key in duplicateKeys)
            {
                // Add error to relevant view models
                var settings = Settings.Where(s => s.Key == key);
                if (settings.Count() > 0) 
                    foreach(var setting in settings) AddRowErrors(setting, nameof(setting.Key), $"Duplicate key: {key}");

                var assets = Assets.Where(a => a.Key == key);
                if (assets.Count() > 0)
                    foreach(var asset in assets) AddRowErrors(asset, nameof(asset.Key), $"Duplicate key: {key}");

                var resources = Resources.Where(r => r.Key == key);
                if (resources.Count() > 0)
                    foreach(var resource in resources) AddRowErrors(resource, nameof(resource.Key), $"Duplicate key: {key}");
            }
        }

        public void ClearRowErrors(ConfigurationRowViewModel model)
        {
            model._errors.Clear();
        }

        // Helper method to add errors to a view model
        public void AddRowErrors(ConfigurationRowViewModel viewModel, string propertyName, string errorMessage)
        {
            if (!viewModel._errors.ContainsKey(propertyName))
            {
                viewModel._errors[propertyName] = new List<string>();
            }
            viewModel._errors[propertyName].Add(errorMessage);
            viewModel.OnErrorsChanged(propertyName);
        }

        public readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _errors.Any();

        public IEnumerable GetErrors(string? propertyName)
        {
            if (ErrorsChanged != null || !_errors.ContainsKey(propertyName)) return Enumerable.Empty<string>();
            return _errors[propertyName];
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}