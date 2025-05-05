using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Events;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UiPath.Studio.Activities.Api;
using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Services.TypeParser;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public class SettingRowViewModel : ConfigurationRowViewModel<SettingItemModel>
    {
        public SettingRowViewModel(IServiceProvider _services, SettingItemModel model, int row) :
            base(_services, model, row)
        {
        }
        public SettingRowViewModel() : this(
            new ServiceCollection()
            .AddSingleton<IEventAggregator>(new EventAggregator())
            .AddSingleton<ITypeParserService>(new TypeParserService())
            .BuildServiceProvider(),
            new SettingItemModel(),
            1
        )
        {
        }
    }
}
