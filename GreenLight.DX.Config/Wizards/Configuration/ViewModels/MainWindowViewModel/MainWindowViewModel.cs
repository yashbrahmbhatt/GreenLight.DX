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
using UiPath.Studio.Activities.Api;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using GreenLight.DX.Shared.Hermes.Models;
using GreenLight.DX.Shared.Hermes.Services;
using GreenLight.DX.Shared.Commands;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly IServiceProvider _services;
        #endregion

        #region Properties

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

        #region Constructors


        public MainWindowViewModel(IServiceProvider services)
        {
            _services = services;
            Info("Initializing MainWindowViewModel", "Constructor");
            InitializeConfigurationService();
            InitializeModelEventHandlers();
            Initialize// Logger();
            InitializeStudioApis();
            InitializeEvents();
            InitializeCommands();
            InitializeConfigurations();
            
            ValidateUniqueNames();
            Initialized += (sender, args) => InitializeConfigurations();
            Initialized?.Invoke(this, EventArgs.Empty);
            Info("MainWindowViewModel initialized", "Constructor");
        }
        public MainWindowViewModel() : this(
            new ServiceCollection().BuildServiceProvider()
        )
        { }

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

