using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Wizards;

namespace GreenLight.DX.Config.Studio
{
    public static class Wizard
    {
        public static IWorkflowDesignApi? API { get; set; }

        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            API = workflowDesignApi;
            try
            {
                var theme = workflowDesignApi.Theme.GetThemeType();
                var wizard = new WizardDefinition()
                {
                    Wizard = new WizardBase()
                    {
                        RunWizard = Run
                    },
                    DisplayName = "Config",
                    Shortcut = new KeyGesture(Key.C, ModifierKeys.Control | ModifierKeys.Alt),
                    Tooltip = "Manage your process configurations",
                };
                WizardCollection collection = new WizardCollection();
                collection.WizardDefinitions.Add(wizard);
                workflowDesignApi.Wizards.Register(collection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Activity? Run()
        {
            if (API == null) return null;
            var model = new Models.ProjectModel();
            var viewModel = new ViewModels.ProjectViewModel(model, API);
            var window = new Windows.MainWindow(viewModel, API);
            window.Show();
            return null;
        }
    }
}
