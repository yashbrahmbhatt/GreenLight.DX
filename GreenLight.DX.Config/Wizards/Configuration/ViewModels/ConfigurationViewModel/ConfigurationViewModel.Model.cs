using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class ConfigurationViewModel
    {
        private ConfigurationModel _model;
        public ConfigurationModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SettingRowViewModel> Settings { get; } = new ObservableCollection<SettingRowViewModel>();
        public ObservableCollection<AssetRowViewModel> Assets { get; } = new ObservableCollection<AssetRowViewModel>();
        public ObservableCollection<ResourceRowViewModel> Resources { get; } = new ObservableCollection<ResourceRowViewModel>();

        public void InitializeModel()
        {
            Model.Settings.CollectionChanged += Model_Settings_CollectionChanged;
            Model.Assets.CollectionChanged += Model_Assets_CollectionChanged;
            Model.Resources.CollectionChanged += Model_Resources_CollectionChanged;
        }

        public void InitializeModelRows()
        {
            foreach (var setting in Model.Settings)
            {
                Settings.Add(new SettingRowViewModel(_services, setting, Model.Settings.IndexOf(setting) + 1));
            }
            foreach (var asset in Model.Assets)
            {
                Assets.Add(new AssetRowViewModel(_services, asset, Model.Assets.IndexOf(asset) + 1));
            }
            foreach (var resource in Model.Resources)
            {
                Resources.Add(new ResourceRowViewModel(_services, resource, Model.Resources.IndexOf(resource) + 1));
            }
        }
        private void Model_Settings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (SettingItemModel newItem in e.NewItems)
                        {
                            Settings.Add(new SettingRowViewModel(_services, newItem, Settings.Count + 1));
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (SettingItemModel oldItem in e.OldItems)
                        {
                            Settings.Remove(Settings.FirstOrDefault(x => x.Model == oldItem));
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Settings.Clear();
                    foreach (var setting in Model.Settings)
                    {
                        Settings.Add(new SettingRowViewModel(_services, setting, Settings.Count + 1));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        private void Model_Assets_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (AssetItemModel newItem in e.NewItems)
                        {
                            Assets.Add(new AssetRowViewModel(_services, newItem, Assets.Count + 1));
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (AssetItemModel oldItem in e.OldItems)
                        {
                            Assets.Remove(Assets.First(x => x.Model == oldItem));
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Assets.Clear();
                    foreach (var asset in Model.Assets)
                    {
                        Assets.Add(new AssetRowViewModel(_services, asset, Assets.Count + 1));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }

        private void Model_Resources_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (ResourceItemModel newItem in e.NewItems)
                        {
                            Resources.Add(new ResourceRowViewModel(_services, newItem, Resources.Count + 1));
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (ResourceItemModel oldItem in e.OldItems)
                        {
                            Resources.Remove(Resources.FirstOrDefault(x => x.Model == oldItem));
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Resources.Clear();
                    foreach (var resource in Model.Resources)
                    {
                        Resources.Add(new ResourceRowViewModel(_services, resource, Resources.Count + 1));
                    }
                    break;
            }
            ValidateUniqueKeys();
        }
    }
}
