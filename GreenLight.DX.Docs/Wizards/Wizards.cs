using GreenLight.DX.Docs.Project;
using GreenLight.DX.Docs.Settings;
using GreenLight.DX.Docs.Xaml;
using GreenLight.DX.Hermes.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Wizards;

namespace GreenLight.DX.Docs.Wizards
{
    public static class Wizard
    {
        public static DocsService DocsService { get; set; }
        public static IHermesService HermesService { get; set; } = new HermesService(Application.Current.Dispatcher);
        public static IServiceProvider Services { get; set; } = new ServiceCollection()
            .AddSingleton<IHermesService>(HermesService)
            .BuildServiceProvider();

        public static WizardDefinition DocumentWizard {get; set; } = new WizardDefinition()
        {
            Wizard = new WizardBase()
            {
                RunWizard = Document,
                RunWizardSettings = new()
                {
                    HasProxySequenceSupport = false
                }
            },
            DisplayName = "Generate Documentation",
            Shortcut = new KeyGesture(Key.D, ModifierKeys.Control | ModifierKeys.Alt),
            Tooltip = "Generate documentation for your workflows and project",
        };

        public static WizardDefinition HermesWizard { get; set; } = new WizardDefinition()
        {
            Wizard = new WizardBase()
            {
                RunWizard = ShowHermes,
                RunWizardSettings = new()
                {
                    HasProxySequenceSupport = false
                }
            },
            DisplayName = "Hermes",
            Shortcut = new KeyGesture(Key.L, ModifierKeys.Control | ModifierKeys.Alt),
            Tooltip = "Open the Hermes window to see the logs of DX packages"
        };

        private static IWorkflowDesignApi Api { get; set; }
        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            Api = workflowDesignApi;
            try
            {
                workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.SettingKey_General_OutputRoot, out var outputRoot);
                workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.SettingKey_General_TemplateRoot, out var templateRoot);
                workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.SettingKey_General_IgnoredPaths, out var ignoredPaths);
                var settings = new DocsSettings()
                {
                    OutputRoot = Path.Combine(workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(), outputRoot),
                    IgnoredPaths = ignoredPaths.Split(",").ToList(),
                    ProjectName = workflowDesignApi.ProjectPropertiesService.GetProjectName(),
                    ProjectRoot = workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(),
                    TemplatesRoot = Path.Combine(workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(), templateRoot),
                };
                DocsService = new DocsService(settings, Services);

                WizardCollection collection = new WizardCollection();
                collection.WizardDefinitions.Add(DocumentWizard);
                collection.WizardDefinitions.Add(HermesWizard);
                workflowDesignApi.Wizards.Register(collection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(JsonConvert.SerializeObject(ex));
            }
        }

        public static Activity Document()
        {
            DocsService.Document();
            return null;
        }

        public static Activity ShowHermes()
        {
            HermesService.ShowHermesWindow();
            return null;
        }

    }
}
