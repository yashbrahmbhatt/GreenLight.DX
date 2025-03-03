using GreenLight.DX.Commands;
using GreenLight.DX.Events;
using GreenLight.DX.Models;
using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GreenLight.DX.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;
        private ConfigurationViewModel _selectedConfig;

        #endregion

        #region Properties

        public ProjectModel Model { get; }

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

        #endregion

        #region Constructors

        public ProjectViewModel(ProjectModel project, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Model = project;
            Initialize();
        }

        public ProjectViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Model = new ProjectModel();
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

            AddConfigurationCommand = new RelayCommand(OnAddConfiguration);

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

        private void OnAddConfiguration()
        {
            var newConfig = new ConfigurationModel { Name = "New Configuration" };
            Model.Configurations.Add(newConfig); // Add to the Model
        }

        private void OnConfigurationDeleted(ConfigurationViewModel configToDelete)
        {
            Model.Configurations.Remove(configToDelete.Model); // Remove from Model
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
    }
}

