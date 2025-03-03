using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Events;
using System.ComponentModel;
using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Config.Studio.Models;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class SettingRowViewModel : ConfigurationRowViewModel<SettingRowModel>
    {
        public static ObservableCollection<Type> SupportedTypes { get; set; } = new ObservableCollection<Type>(TypeParsers.Parsers.Keys);


        public SettingRowViewModel(IEventAggregator eventAggregator, SettingRowModel model, PropertyChangedEventHandler propertyChanged) : base(eventAggregator, model, propertyChanged)
        {
            Model = model;
        }


        public string Value
        {
            get => Model.Value;
            set
            {
                if (Model.Value != value)
                {
                    Model.Value = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
