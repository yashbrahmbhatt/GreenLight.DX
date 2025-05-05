using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.Events
{
    public class ConfigurationEditStartEvent : PubSubEvent<ConfigurationViewModel> { }

}
