using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Config.Studio.Services;
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

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class AssetRowViewModel : ConfigurationRowViewModel<AssetItem>
    {

        public ObservableCollection<Folder> AssetFolders
        {
            get
            {
                return Model._orchestratorService.Folders;
            }
        }
        public ObservableCollection<Asset> AssetNames
        {
            get
            {
                return Model._orchestratorService.Assets.FirstOrDefault(f => f.Key.DisplayName == AssetFolder).Value;
            }
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
        public AssetRowViewModel(IServiceProvider _services, AssetItem model, int row)
            : base(_services, model, row)
        {
            Model = model;
        }
        public AssetRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new AssetItem(),
            1
        )
        {
        }
    }
}
