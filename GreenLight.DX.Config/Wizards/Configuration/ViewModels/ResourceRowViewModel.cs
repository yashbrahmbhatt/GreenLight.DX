using GreenLight.DX.Config.Services.TypeParser;
using GreenLight.DX.Config.Services.Configuration.Models;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public class ResourceRowViewModel : ConfigurationRowViewModel<ResourceItemModel>
    {

        public ResourceRowViewModel(IServiceProvider _services, ResourceItemModel model, int row)
            : base(_services, model, row)
        {
            Model = model;
        }
        public ResourceRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new ResourceItemModel(),
            1
        )
        { }
        public string Path
        {
            get => Model.Path;
            set
            {
                if (Model.Path != value)
                {
                    Model.Path = value;
                    ValidateRequired(value);
                    OnPropertyChanged();
                }
            }
        }

        public string Folder
        {
            get => Model.Folder;
            set
            {
                if (Model.Folder != value)
                {
                    Model.Folder = value;
                    ValidateRequired(value);
                    OnPropertyChanged();
                }
            }
        }

        public string Bucket
        {
            get => Model.Bucket;
            set
            {
                if (Model.Bucket != value)
                {
                    Model.Bucket = value;
                    ValidateRequired(value);
                    OnPropertyChanged();
                }
            }
        }

        public ResourceRowType ResourceType
        {
            get => Model.ResourceType;
            set
            {
                if (Model.ResourceType != value)
                {
                    Model.ResourceType = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
