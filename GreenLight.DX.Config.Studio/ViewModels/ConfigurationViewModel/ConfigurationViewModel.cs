using GreenLight.DX.Config.Studio.Events;
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
using GreenLight.DX.Config.Shared.Models;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class ConfigurationViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IServiceProvider _services;

        #endregion

        #region Properties
        public ObservableCollection<KeyValuePair<string, IEnumerable<string>>> AssetsMap { get; }
        

        public ObservableCollection<string> FolderNames { get; } = new ObservableCollection<string>();

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

        public ConfigurationViewModel(IServiceProvider services, Configuration model, ObservableCollection<KeyValuePair<string, IEnumerable<string>>> assetsMap)
        {
            _services = services;
            Model = model;
            AssetsMap = assetsMap;
            AssetsMap.CollectionChanged += AssetsMap_CollectionChanged;

            InitializeEvents();
            InitializeCommands();
            InitializeModel();
            InitializeModelRows();
            InitializeAssetFolders();
            ValidateUniqueKeys();

        }

        public ConfigurationViewModel() : this(
            new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider(),
            new Configuration(),
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
    }
}
