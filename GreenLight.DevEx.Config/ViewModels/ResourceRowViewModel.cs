using GreenLight.DX.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.ViewModels
{
    public class ResourceRowViewModel : ConfigurationRowViewModel<ResourceRowModel>
    {
        public static ObservableCollection<Type> SupportedTypes { get; set; } = new ObservableCollection<Type>() {  typeof(string), typeof(DataTable), typeof(DataSet)};

        public ResourceRowViewModel(IEventAggregator eventAggregator, ResourceRowModel model, PropertyChangedEventHandler propertyChanged) 
            : base(eventAggregator, model, propertyChanged)
        {
            Model = model;
        }

        public string Path
        {
            get => Model.Path;
            set
            {
                if (Model.Path != value)
                {
                    Model.Path = value;
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
                    OnPropertyChanged();
                }
            }
        }
    }
}
