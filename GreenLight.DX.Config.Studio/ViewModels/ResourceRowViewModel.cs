using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Config.Studio.Services;
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

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class ResourceRowViewModel : ConfigurationRowViewModel<ResourceItem>
    {

        public ResourceRowViewModel(IServiceProvider _services, ResourceItem model, int row)
            : base(_services, model, row)
        {
            Model = model;
        }
        public ResourceRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new ResourceItem(),
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
