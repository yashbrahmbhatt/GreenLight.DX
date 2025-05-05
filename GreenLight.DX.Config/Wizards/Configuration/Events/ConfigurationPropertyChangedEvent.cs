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
    public class ConfigurationPropertyChangedEvent : PubSubEvent<ConfigurationPropertyChangedEventArgs>
    {
    }

    public class ConfigurationPropertyChangedEventArgs
    {
        public ConfigurationViewModel ViewModel { get; set; }
        public PropertyChangedEventArgs EventArgs { get; set; }
    }
}
