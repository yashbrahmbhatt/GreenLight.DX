using GreenLight.DX.Config.Services.TypeParser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ITypeParserService _typeParserService;

        public void InitializeTypeParserService()
        {
            _typeParserService = _services.GetRequiredService<ITypeParserService>();
        }
    }
}
