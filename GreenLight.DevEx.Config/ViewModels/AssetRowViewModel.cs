using GreenLight.DX.Misc;
using GreenLight.DX.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.ViewModels
{
    public class AssetRowViewModel : ConfigurationRowViewModel
    {
        public new AssetRowModel Model { get; set; } = new AssetRowModel();
        public static ObservableCollection<Type> SupportedTypes { get; set; } = new ObservableCollection<Type>(TypeParsers.Parsers.Keys);

        public AssetRowViewModel(IEventAggregator eventAggregator, AssetRowModel model) : base(eventAggregator, model)
        {
            Model = model;
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
                    OnPropertyChanged();
                }
            }
        }
    }
}
