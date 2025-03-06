using GreenLight.DX.Shared.Hermes.Services;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
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
            try
            {
                if (API == null) throw new NullReferenceException($"WorkflowAPI was null");
                var hermes = new HermesService(Application.Current.Dispatcher);
                var services = new ServiceCollection()
                    .AddSingleton<IEventAggregator>(new EventAggregator())
                    .AddSingleton<IHermesService>(hermes)
                    .AddSingleton<IWorkflowDesignApi>(API)
                    .BuildServiceProvider();
                var viewModel = new ViewModels.MainWindowViewModel(services, new Models.ProjectModel());
                var window = new Windows.MainWindow(services, viewModel);
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return null;
        }
    }
}
