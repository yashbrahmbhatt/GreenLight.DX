using GreenLight.DX.Config.Services.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel
    {
        // Assuming Debug and Info methods exist within this class or a base class.
        // Example stubs (replace with your actual logging implementation if needed):
        // private void Debug(string message, string callerName) { /* Your debug logging here */ }
        // private void Info(string message, string callerName) { /* Your info logging here */ }
        // private IConfigurationService _configurationService; // Assuming this service exists
        // private IServiceProvider _services; // Assuming this service provider exists
        // public ConfigurationViewModel SelectedConfig { get; set; } // Assuming this property exists
        // private void ValidateUniqueNames() { /* Assuming this method exists */ }


        public ObservableCollection<ConfigurationViewModel> Configurations { get; } = new ObservableCollection<ConfigurationViewModel>();

        private void Model_Configurations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug($"Model.Configurations collection changed. Action: {e.Action}", nameof(Model_Configurations_CollectionChanged)); // Existing logging refined

            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Debug($"Adding {e.NewItems?.Count} new configurations", nameof(Model_Configurations_CollectionChanged));
                    if (e.NewItems != null)
                    {
                        foreach (ConfigurationModel newConfig in e.NewItems)
                        {
                            Configurations.Add(new ConfigurationViewModel(_services, newConfig));
                            // Optionally log each item added:
                            // Debug($"Added configuration: {newConfig.Name ?? "Unnamed"}", nameof(Model_Configurations_CollectionChanged));
                        }
                        // Set SelectedConfig after all additions, if desired behaviour
                        if (e.NewItems.Count > 0 && Configurations.Count >= e.NewItems.Count)
                        {
                            SelectedConfig = Configurations[Configurations.Count - 1];
                            Debug($"Selected newly added configuration.", nameof(Model_Configurations_CollectionChanged));
                        }
                    }
                    Debug($"Finished adding configurations", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Debug($"Removing {e.OldItems?.Count} configurations", nameof(Model_Configurations_CollectionChanged));
                    if (e.OldItems != null)
                    {
                        foreach (ConfigurationModel oldConfig in e.OldItems)
                        {
                            var viewModelToRemove = Configurations.FirstOrDefault(x => x.Model == oldConfig);
                            if (viewModelToRemove != null)
                            {
                                Configurations.Remove(viewModelToRemove);
                                // Optionally log each item removed:
                                // Debug($"Removed configuration: {oldConfig.Name ?? "Unnamed"}", nameof(Model_Configurations_CollectionChanged));
                            }
                            else
                            {
                                // Log if a corresponding ViewModel wasn't found (might indicate a bug)
                                Debug($"Could not find ViewModel for removed configuration: {oldConfig.Name ?? "Unnamed"}", nameof(Model_Configurations_CollectionChanged));
                            }
                        }
                    }
                    Debug($"Finished removing configurations", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    Debug($"Handling Replace action (not implemented)", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    // Add logic here if needed for Replace
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    Debug($"Handling Move action (not implemented)", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    // Add logic here if needed for Move
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    Debug("Handling Reset action", nameof(Model_Configurations_CollectionChanged));
                    Configurations.Clear();
                    Debug("Cleared Configurations collection", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    // Re-populate from the source model
                    if (_configurationService?.Project?.Configurations != null)
                    {
                        foreach (var config in _configurationService.Project.Configurations)
                        {
                            Configurations.Add(new ConfigurationViewModel(_services, config));
                            // Optionally log each item added during reset:
                            // Debug($"Added configuration during reset: {config.Name ?? "Unnamed"}", nameof(Model_Configurations_CollectionChanged));
                        }
                        Debug($"Re-populated Configurations with {_configurationService.Project.Configurations.Count} items", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    }
                    else
                    {
                        Debug("Source configurations collection is null or Project is null during Reset", nameof(Model_Configurations_CollectionChanged)); // Added logging
                    }
                    break;
            }

            ValidateUniqueNames();
            Debug("ValidateUniqueNames called after collection change", nameof(Model_Configurations_CollectionChanged)); // Added logging
        }

        public void InitializeModelEventHandlers()
        {
            Debug("Initializing model event handlers", nameof(InitializeModelEventHandlers)); // Existing logging
            if (_configurationService?.Project?.Configurations != null)
            {
                _configurationService.Project.Configurations.CollectionChanged += Model_Configurations_CollectionChanged;
                Debug("Attached Model_Configurations_CollectionChanged handler", nameof(InitializeModelEventHandlers)); // Added logging
            }
            else
            {
                Error("Cannot attach Model_Configurations_CollectionChanged handler: _configurationService.Project.Configurations is null", nameof(InitializeModelEventHandlers)); // Added logging
            }
        }

        public void InitializeConfigurations()
        {
            Info("Initializing configurations", nameof(InitializeConfigurations)); // Existing logging

            Configurations.Clear();
            Debug("Cleared Configurations collection for initialization", nameof(InitializeConfigurations)); // Added logging

            if (_configurationService?.Project?.Configurations != null)
            {
                foreach (var config in _configurationService.Project.Configurations)
                {
                    Configurations.Add(new ConfigurationViewModel(_services, config));
                    // Optionally log each item added:
                    // Debug($"Initialized configuration: {config.Name ?? "Unnamed"}", nameof(InitializeConfigurations));
                }
                Debug($"Initialized Configurations with {_configurationService.Project.Configurations.Count} items from source", nameof(InitializeConfigurations)); // Added logging

                if (Configurations.Any())
                {
                    SelectedConfig = Configurations[0];
                    Debug("Selected the first configuration", nameof(InitializeConfigurations)); // Added logging
                }
                else
                {
                    Debug("No configurations available to select", nameof(InitializeConfigurations)); // Added logging
                }
            }
            else
            {
                Debug("Source configurations collection is null or Project is null during initialization", nameof(InitializeConfigurations)); // Added logging
            }


            Info("Configurations initialized", nameof(InitializeConfigurations)); // Existing logging
        }
    }
}