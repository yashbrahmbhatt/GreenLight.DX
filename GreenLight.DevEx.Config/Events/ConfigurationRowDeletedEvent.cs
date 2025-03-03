using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLight.DX.ViewModels;
using GreenLight.DX.Models;

namespace GreenLight.DX.Events
{
    public class ConfigurationRowDeletedEvent<T> : PubSubEvent<ConfigurationRowViewModel<T>> where T : ConfigurationRowModel
    { }
}
