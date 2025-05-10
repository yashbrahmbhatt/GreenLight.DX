using Newtonsoft.Json;
using System;
using System.Activities;
using System.Activities.DesignViewModels;
using System.Activities.ViewModels.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UiPath.Platform.ResourceHandling;
using UiPath.Shared.Activities;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Activities.ViewModels
{
    public class LoadConfigViewModel : DesignPropertiesViewModel
    {
        private readonly IWorkflowDesignApi _workflowDesignApi;
        public DesignInArgument<ILocalResource> ConfigurationPath { get; set; }
        public DesignInArgument<string> Configuration { get; set; }
        public List<string> ConfigurationOptions { get; set; } = new List<string>();
        public DesignOutArgument<object> ConfigurationObject { get; set; }

        public LoadConfigViewModel(IDesignServices services) : base(services)
        {
            _workflowDesignApi = services.GetService<IWorkflowDesignApi>();
            if (_workflowDesignApi == null)
            {
                throw new ArgumentNullException(nameof(_workflowDesignApi));
            }
            try
            {
                //_configurationService = new ConfigurationService(_workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(), "Configurations\\Configurations.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        protected override void InitializeModel()
        {
            /*
             * The base call will initialize the properties of the view model with the values from the xaml or with the default values from the activity
             */
            //_configurationDynamicDataSourceBuilder = new ConfigurationDynamicDataSourceBuilder(_configurationService);
            base.InitializeModel();
            try
            {
                //_project = JsonConvert.DeserializeObject<ProjectModel>(File.ReadAllText(Path.Combine(_workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(), "Configurations\\Configurations.json")));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int index = 0;
            ConfigurationPath.IsRequired = true;
            ConfigurationPath.IsPrincipal = true;
            ConfigurationPath.DisplayName = "Configuration FilePath";
            ConfigurationPath.IsVisible = true;
            ConfigurationPath.OrderIndex = ++index;

            Configuration.IsRequired = true;
            Configuration.IsPrincipal = true;
            Configuration.DisplayName = "Configuration";
            Configuration.IsVisible = true;
            Configuration.OrderIndex = ++index;
            //Configuration.RegisterService<IDynamicDataSourceBuilder>(_configurationDynamicDataSourceBuilder);
            //Configuration.SupportsDynamicDataSourceQuery = true;

            ConfigurationObject.IsVisible = true;
            ConfigurationObject.IsPrincipal = true;
            ConfigurationObject.DisplayName = "Configuration Object";
            ConfigurationObject.OrderIndex = ++index;




            PersistValuesChangedDuringInit(); // mandatory call only when you change the values of properties during initialization
        }


    }

}
