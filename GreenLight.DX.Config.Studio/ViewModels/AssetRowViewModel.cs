using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Config.Studio.Models;
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

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class AssetRowViewModel : ConfigurationRowViewModel<AssetRowModel>
    {
        public static ObservableCollection<Type> SupportedTypes { get; set; } = new ObservableCollection<Type>(TypeParsers.Parsers.Keys);
        public ObservableCollection<KeyValuePair<string, IEnumerable<string>>> AssetsMap { get; set; }
        public ListCollectionView Folders { get; set; }
        public ListCollectionView AssetNames { get; set; }



        public AssetRowViewModel(IEventAggregator eventAggregator, AssetRowModel model, PropertyChangedEventHandler propertyChanged, ObservableCollection<KeyValuePair<string, IEnumerable<string>>> assetMap)
            : base(eventAggregator, model, propertyChanged)
        {
            AssetsMap = assetMap;
            Folders = new ListCollectionView(AssetsMap.Select(a => a.Key).ToList());
            OnAssetsMapUpdated(null, null);
            assetMap.CollectionChanged += OnAssetsMapUpdated;
            Model = model;
        }
        public AssetRowViewModel() : base(new EventAggregator(), new AssetRowModel(), null)
        {
            
            AssetsMap = new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
            {
                { new KeyValuePair<string, IEnumerable<string>>("Folder1", new List<string> { "Asset1", "Asset2" }) },
                { new KeyValuePair<string, IEnumerable<string>>("Folder2", new List<string> { "Asset3", "Asset4" }) }
            };
            Folders = new ListCollectionView(AssetsMap.Select(a => a.Key).ToList()); ;
            OnAssetsMapUpdated(null, null);
            AssetsMap.CollectionChanged += OnAssetsMapUpdated;
            Model = new AssetRowModel();
        }

        public string AssetName
        {
            get => Model.AssetName;
            set
            {
                if (Model.AssetName != value)
                {
                    Model.AssetName = value;
                    OnPropertyChanged();
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
                    OnAssetFolderUpdated();
                    OnPropertyChanged();
                }
            }
        }

        public void OnAssetsMapUpdated(object? sender, NotifyCollectionChangedEventArgs? args)
        {
            for (var i = 0; i < Folders.Count; i++)
            {
                Folders.RemoveAt(i);
            }
            foreach (var folder in AssetsMap)
            {
                Folders.AddNewItem(folder.Key);
                Folders.CommitNew();
            }
            Folders.Refresh();
            OnPropertyChanged(nameof(Folders));
        }
        public void OnAssetFolderUpdated()
        {

            if (!AssetsMap.Any(AssetsMap => AssetsMap.Key == AssetFolder))
            {
                return;
            }
            for (var i = 0; i < AssetNames.Count; i++)
            {
                AssetNames.RemoveAt(i);
            }
            var assets = AssetsMap.FirstOrDefault(x => x.Key == AssetFolder).Value;
            if (assets == null)
            {
                return;
            }
            foreach (var asset in assets)
            {
                AssetNames.AddNewItem(asset);
                AssetNames.CommitNew();
            }
            AssetNames.Refresh();
            OnPropertyChanged(nameof(AssetNames));
        }
    }
}
