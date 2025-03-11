using GreenLight.DX.Config.Studio.Models;
using GreenLight.DX.Config.Studio.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.Events
{
    public class ConfigurationRowPropertyChangedEvent<T> : PubSubEvent<ConfigurationRowPropertyChangedEventArgs<T>> where T : ConfigurationRowModel
    { }

    public class  ConfigurationRowPropertyChangedEventArgs<T> where T : ConfigurationRowModel 
    {
        public ConfigurationRowViewModel<T> ViewModel { get; set; }
        public PropertyChangedEventArgs EventArgs { get; set; }
    }

}
