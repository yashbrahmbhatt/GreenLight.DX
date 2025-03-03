using GreenLight.DX.Config.Studio.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.Events
{
    public class ConfigurationDeletedEvent : PubSubEvent<ConfigurationViewModel> { }
}
