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
using Microsoft.Extensions.DependencyInjection;
using UiPath.Studio.Activities.Api;
using GreenLight.DX.Config.Studio.Services;
using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Shared.Models;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public class SettingRowViewModel : ConfigurationRowViewModel<SettingItem>
    {
        public SettingRowViewModel(IServiceProvider _services, SettingItem model, int row) : 
            base(_services, model, row)
        {
        }
        public SettingRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new SettingItem(), 
            1
        ) {
        }        
    }
}
