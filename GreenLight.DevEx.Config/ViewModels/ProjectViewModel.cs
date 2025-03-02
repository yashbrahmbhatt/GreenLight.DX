using GreenLight.DX.Commands;
using GreenLight.DX.Events;
using GreenLight.DX.Models;
using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq; // Remove this using statement, it is not used anymore
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GreenLight.DX.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator _eventAggregator;
        public ProjectModel Model { get; }

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
        public ICommand AddConfigurationCommand { get; set; }

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

        public void Initialize()
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

        private void OnAddConfiguration()
        {
            var newConfig = new ConfigurationModel { Name = "New Configuration" };
            Model.Configurations.Add(newConfig); // Add to the Model
            //Configurations.Add(new ConfigurationViewModel(newConfig, _eventAggregator)); // Add to the ViewModel's collection
        }

        private void OnConfigurationDeleted(ConfigurationViewModel configToDelete)
        {
            Model.Configurations.Remove(configToDelete.Model); // Remove from Model
           // Configurations.Remove(configToDelete); // Remove from ViewModel collection
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ValidateUniqueNames();
        }

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
                    AddError(config, nameof(config.Name), $"Duplicate configuration name: {config.Name}");
                }
                else
                {
                    RemoveError(config, nameof(config.Name));
                }
            }
        }

        private void AddError(ConfigurationViewModel viewModel, string propertyName, string errorMessage)
        {
            if (!viewModel._errors.ContainsKey(propertyName))
            {
                viewModel._errors[propertyName] = new List<string>();
            }
            viewModel._errors[propertyName].Add(errorMessage);
            viewModel.OnErrorsChanged(propertyName);
        }

        private void RemoveError(ConfigurationViewModel viewModel, string propertyName)
        {
            if (viewModel._errors.ContainsKey(propertyName))
            {
                viewModel._errors.Remove(propertyName);
                viewModel.OnErrorsChanged(propertyName);
            }
        }
    }
}