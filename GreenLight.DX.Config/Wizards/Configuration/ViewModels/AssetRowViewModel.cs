using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Services.TypeParser;
using GreenLight.DX.Shared.Commands;
using GreenLight.DX.Shared.Services.Orchestrator.GetAssets;
using GreenLight.DX.Shared.Services.Orchestrator.GetFolders;
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

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public class AssetRowViewModel : ConfigurationRowViewModel<AssetItemModel>
    {
        public ObservableCollection<Folder> Folders
        {
            get
            {
                return Model._orchestratorService.Folders;
            }
        }
        public ObservableCollection<Asset>? Assets
        {
            get
            {
                return Model._orchestratorService.Assets.FirstOrDefault(kvp => kvp.Key == AssetFolder).Value;
            }
        }

        public Asset? AssetName
        {
            get => Model.AssetObject;
            set
            {
                if (Model.AssetObject != value)
                {
                    Model.AssetObject = value;
                    OnPropertyChanged();
                    ValidateRequired(value);
                }
            }
        }

        public Folder? AssetFolder
        {
            get => Model.FolderObject;
            set
            {
                if (Model.FolderObject != value)
                {
                    Model.FolderObject = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Assets));
                    ValidateRequired(value);
                }
            }
        }
        public AssetRowViewModel(IServiceProvider _services, AssetItemModel model, int row)
            : base(_services, model, row)
        {
            Model = model;
            Model._orchestratorService.Folders.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(Folders));
            Model._orchestratorService.Assets.CollectionChanged += (object ? sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(Assets));
        }
        public AssetRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new AssetItemModel(),
            1
        )
        {
        }
    }
}
