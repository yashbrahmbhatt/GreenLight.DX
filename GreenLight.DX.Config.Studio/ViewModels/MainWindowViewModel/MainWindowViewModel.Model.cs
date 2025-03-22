using GreenLight.DX.Config.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class MainWindowViewModel
    {
        public Project Model
        {
            get => _configurationService.Project;
            set
            {
                if (_configurationService.Project != value)
                {
                    _configurationService.Project = value;
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

        private void Model_Configurations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug("Model.Configurations collection changed", "Model_Configurations_CollectionChanged");
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Debug($"Adding {e.NewItems?.Count} new configurations", "Model_Configurations_CollectionChanged");
                    if (e.NewItems != null)
                    {
                        foreach (Configuration newConfig in e.NewItems)
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
                        foreach (Configuration oldConfig in e.OldItems)
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

        public void InitializeModelEventHandlers()
        {
            Model.Configurations.CollectionChanged += Model_Configurations_CollectionChanged;
        }

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
    }
}
