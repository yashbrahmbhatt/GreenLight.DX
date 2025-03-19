using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Config.Studio.Services;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class AssetRowViewModel : ConfigurationRowViewModel<AssetItem>
    {
        private readonly ObservableCollection<KeyValuePair<string, IEnumerable<string>>> _assetsMap;

        public ObservableCollection<string> AssetFolders { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> AssetNames { get; } = new ObservableCollection<string>();

        public string AssetName
        {
            get => Model.AssetName;
            set
            {
                if (Model.AssetName != value)
                {
                    Model.AssetName = value;
                    OnPropertyChanged();
                    ValidateRequired(value);
                }
            }
        }

        public string AssetFolder
        {
            get => Model.AssetFolder;
            set
            {
                if (Model.AssetFolder != value)
                {
                    Model.AssetFolder = value;
                    OnPropertyChanged();
                    ValidateRequired(value);
                }
            }
        }
        public AssetRowViewModel(IServiceProvider _services, AssetItem model, int row,
            ObservableCollection<KeyValuePair<string, IEnumerable<string>>> map)
            : base(_services, model, row)
        {
            Model = model;
            _assetsMap = map;
            PropertyChanged += OnFolderChanged;
            RefreshFolders();
        }
        public AssetRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new AssetItem(),
            1,
            new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
            {
                new KeyValuePair<string, IEnumerable<string>>("Folder", new List<string>() { "Asset1", "Asset2", "Asset3" }),
                new KeyValuePair<string, IEnumerable<string>>("Folder2", new List<string>() { "Asset4", "Asset5", "Asset6" }),
                new KeyValuePair<string, IEnumerable<string>>("Folder3", new List<string>() { "Asset7", "Asset8", "Asset9" }),
            }
        )
        { 
            RefreshFolders();
        }

        public void RefreshFolders()
        {
            AssetFolders.Clear();
            if (_assetsMap == null) return;
            foreach (var value in _assetsMap)
            {
                AssetFolders.Add(value.Key);
            }
            OnPropertyChanged(nameof(AssetFolders));
        }

        public void RefreshNames()
        {
            AssetNames.Clear();
            if (_assetsMap == null) return;
            foreach (var value in _assetsMap.First(x => x.Key == Model.AssetFolder).Value)
            {
                AssetNames.Add(value);
            }
            OnPropertyChanged(nameof(AssetNames));
        }


        public void OnFolderChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AssetFolder")
            {
                RefreshNames();
            }
        }
    }
}
