using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.Events
{
    public class ConfigurationRowPropertyChangedEvent<T> : PubSubEvent<ConfigurationRowPropertyChangedEventArgs<T>> where T : ConfigItemModel
    { }

    public class ConfigurationRowPropertyChangedEventArgs<T> where T : ConfigItemModel
    {
        public ConfigurationRowViewModel<T> ViewModel { get; set; }
        public PropertyChangedEventArgs EventArgs { get; set; }
    }

}
