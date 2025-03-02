using GreenLight.DX.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Events
{
    public class ConfigurationDeletedEvent : PubSubEvent<ConfigurationViewModel> { }
}
