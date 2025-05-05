using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using GreenLight.DX.Config.Services.Configuration.Models;

namespace GreenLight.DX.Config.Wizards.Configuration.Events
{
    public class ConfigurationRowDeletedEvent<T> : PubSubEvent<ConfigurationRowViewModel<T>> where T : ConfigItemModel
    { }
}
