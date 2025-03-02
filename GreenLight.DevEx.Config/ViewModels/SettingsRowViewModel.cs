using GreenLight.DX.Models;
using GreenLight.DX.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Events;

namespace GreenLight.DX.ViewModels
{
    public class SettingRowViewModel : ConfigurationRowViewModel
    {
        public new SettingRowModel Model { get; set; } = new SettingRowModel();
        public static ObservableCollection<Type> SupportedTypes { get; set; } = new ObservableCollection<Type>(TypeParsers.Parsers.Keys);


        public SettingRowViewModel(IEventAggregator eventAggregator, SettingRowModel model) : base(eventAggregator, model)
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
