using GreenLight.DX.Config.Activities.Helpers;
using GreenLight.DX.Config.Services.Configuration.Models;
using Newtonsoft.Json;
using ReflectionMagic;
using System.Activities;
using System.Activities.DesignViewModels;
using System.Activities.Statements;
using System.Activities.ViewModels;
using System.Activities.ViewModels.Interfaces;
using System.ComponentModel;
using System.IO;
using UiPath.Studio.Activities.Api.ProjectProperties;

namespace GreenLight.DX.Config.Activities.ViewModels
{
    public class REFrameworkViewModel : DesignPropertiesViewModel
    {
        /*
         * The result property comes from the activity's base class
         */
        public DesignProperty<ActivityAction<IObjectContainer>> InitializeState { get; set; }
        public DesignProperty<ActivityAction<IObjectContainer>> ExecuteState { get; set; }
        public DesignProperty<ActivityAction<IObjectContainer>> FinalizeState { get; set; }
        public DesignProperty<bool> Debug { get; set; } // Debug flag
        public REFrameworkViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            /*
             * The base call will initialize the properties of the view model with the values from the xaml or with the default values from the activity
             */
            base.InitializeModel();
            //InitializeState.DisplayName = "Initialize State";
            //ExecuteState.DisplayName = "Execute State";
            //FinalizeState.DisplayName = "Finalize State";
            //InitializeState.Value.Handler = new Sequence { DisplayName = nameof(InitializeState) };
            //ExecuteState.Value.Handler = new Sequence { DisplayName = nameof(ExecuteState) };
            //FinalizeState.Value.Handler = new Sequence { DisplayName = nameof(FinalizeState) };
            //PersistValuesChangedDuringInit(); // mandatory call only when you change the values of properties during initialization
        }

        public List<string> LoadConfigs()
        {

            var configurationsPath = Path.Combine(Directory.GetCurrentDirectory(), "Configurations", "Configurations.json");
            var project = JsonConvert.DeserializeObject<ProjectModel>(File.ReadAllText(configurationsPath));
            var configurations = project.Configurations.Select(c => c.Name).ToList();
            return configurations;

        }
    }



}
