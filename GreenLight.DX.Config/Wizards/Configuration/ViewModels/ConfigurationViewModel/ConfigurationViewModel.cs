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
using GreenLight.DX.Shared.Commands;
using GreenLight.DX.Shared.Services.Orchestrator.GetFolders;
using GreenLight.DX.Shared.Services.Orchestrator.GetAssets;
using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Services;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class ConfigurationViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IServiceProvider _services;

        #endregion

        #region Properties

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

        #region Constructors

        public ConfigurationViewModel(IServiceProvider services, Services.Configuration.Models.ConfigurationModel model)
        {
            _services = services;
            Model = model;

            InitializeEvents();
            InitializeCommands();
            InitializeModel();
            InitializeModelRows();
            ValidateUniqueKeys();

        }

        public ConfigurationViewModel() : this(
            new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider(),
            new Services.Configuration.Models.ConfigurationModel()
        )
        { }

        #endregion
    }
}
