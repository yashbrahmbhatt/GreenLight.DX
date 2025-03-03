using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLight.DX.Config.Studio.Models;
using GreenLight.DX.Config.Studio.ViewModels;

namespace GreenLight.DX.Config.Studio.Events
{
    public class ConfigurationRowDeletedEvent<T> : PubSubEvent<ConfigurationRowViewModel<T>> where T : ConfigurationRowModel
    { }
}
