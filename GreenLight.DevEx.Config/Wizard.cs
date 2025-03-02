using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Wizards;

namespace GreenLight.DX
{
    public static class Wizard
    {

        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            try
            {
                var theme = workflowDesignApi.Theme.GetThemeType();
                var wizard = new WizardDefinition()
                {
                    Wizard = new WizardBase(),
                    DisplayName = "Config",
                    Shortcut = new KeyGesture(Key.F9, ModifierKeys.Control | ModifierKeys.Shift),
                    Tooltip = "Manage your process configurations"
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
    }
}
