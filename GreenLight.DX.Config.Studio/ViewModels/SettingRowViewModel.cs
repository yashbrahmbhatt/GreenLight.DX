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
using Microsoft.Extensions.DependencyInjection;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class SettingRowViewModel : ConfigurationRowViewModel<SettingRowModel>
    {
        private ObservableCollection<Type> _supportedTypes = new ObservableCollection<Type>(TypeParsers.Parsers.Keys);
        public ObservableCollection<Type> SupportedTypes
        {
            get => _supportedTypes;
            set
            {
                if (_supportedTypes != value)
                {
                    _supportedTypes = value;
                    OnPropertyChanged();
                }
            }
        }

        public SettingRowViewModel(IServiceProvider _services, SettingRowModel model, int row) : 
            base(_services, model, row)
        {
            Model = model;
            SupportedTypes = new ObservableCollection<Type>(TypeParsers.Parsers.Keys);
        }
        public SettingRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .BuildServiceProvider(),
            new SettingRowModel(), 
            1
        ) { }


        public string Value
        {
            get => Model.Value;
            set
            {
                if (Model.Value != value)
                {
                    Model.Value = value;
                    ValidateProperty(value, nameof(Value));
                    OnPropertyChanged();
                }
            }
        }
    }
}
