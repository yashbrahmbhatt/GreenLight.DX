using GreenLight.DX.Config.Shared.Models;
using Newtonsoft.Json;
using ReflectionMagic;
using System.Activities;
using System.Activities.DesignViewModels;
using System.Activities.ViewModels;
using System.Activities.ViewModels.Interfaces;
using System.ComponentModel;
using UiPath.Shared;
using UiPath.Studio.Activities.Api.ProjectProperties;

namespace GreenLight.DX.Config.Activities.ViewModels
{
    public class ActivityTemplateViewModel : DesignPropertiesViewModel
    {
        /*
         * The result property comes from the activity's base class
         */
        public DesignOutArgument<int> Result { get; set; }
        public DesignInArgument<ActivityFunc<string, string>> InitializeState { get; set; }

        public ActivityTemplateViewModel(IDesignServices services) : base(services)
        {
        }

        public DesignProperty<string> ConfigurationType { get; set; }

        protected override void InitializeModel()
        {
            /*
             * The base call will initialize the properties of the view model with the values from the xaml or with the default values from the activity
             */
            base.InitializeModel();
            //ConfigurationName.Name = "Configuration Name";
            //ConfigurationName.IsVisible = true;
            //ConfigurationName.IsRequired = true;
            //ConfigurationName.AddMenuAction(new System.Activities.ViewModels.MenuAction()
            //{
            //    DisplayName = "Set Configuration Name",
            //    IsVisible = true,
                
            //});

            ConfigurationType.Name = "Configuration Type";
            ConfigurationType.IsVisible = true;
            ConfigurationType.IsRequired = true;

            PersistValuesChangedDuringInit(); // mandatory call only when you change the values of properties during initialization
        }

        public List<string> LoadConfigs()
        {
            
            var configurationsPath = Path.Combine(Directory.GetCurrentDirectory(), "Configurations", "Configurations.json");
            var project = JsonConvert.DeserializeObject<Project>(File.ReadAllText(configurationsPath));
            var configurations = project.Configurations.Select(c => c.Name).ToList();
            return configurations;

        }
    }

    

}
