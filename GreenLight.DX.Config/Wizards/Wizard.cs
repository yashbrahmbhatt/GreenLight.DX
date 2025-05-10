using GreenLight.DX.Config.Services.Configuration;
using GreenLight.DX.Config.Services.TypeParser;
using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Hermes.Services;
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
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using GreenLight.DX.Config.Wizards.Configuration.Windows;
using GreenLight.DX.Config.Settings;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using GreenLight.DX.Shared.Services.Orchestrator;

namespace GreenLight.DX.Config.Wizards
{
    public static class Wizard
    {
        public static IServiceProvider Services { get; set; }
        public static ConfigurationService ConfigurationService { get; set; }
        public static IHermesService HermesService { get; set; }
        public static OrchestratorService OrchestratorService { get; set; }

        public static WizardDefinition ConfigWizardDefinition = new WizardDefinition()
        {
            Wizard = new WizardBase()
            {
                RunWizard = RunConfig
            },
            DisplayName = "Manage",
            Shortcut = new KeyGesture(Key.C, ModifierKeys.Control | ModifierKeys.Alt),
            Tooltip = "Manage your process configurations",
        };

        public static WizardDefinition HermesWizardDefinition = new WizardDefinition()
        {
            Wizard = new WizardBase()
            {
                RunWizard = RunHermes
            },
            DisplayName = "Logs",
            Tooltip = "Look at the logs of the configuration wizard"
        };

        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            MessageBox.Show("Create");
            try
            {
                HermesService = new HermesService(Application.Current.Dispatcher);
                OrchestratorService = new OrchestratorService(workflowDesignApi);
                MessageBox.Show(JsonConvert.SerializeObject(string.Join("/",workflowDesignApi.OnlineServicesConfiguration.Orchestrator.ExtendedSettings["forwardLogsEndpoint"].Split("/").Select(p => p.Replace("\\\"", "").Take(5))), Formatting.Indented));
                var theme = workflowDesignApi.Theme.GetThemeType();
                var wizard = new WizardDefinition()
                {
                    DisplayName = "Config",
                    Tooltip = "Wizards that are a part of the Configuration Management DX package",
                };
                wizard.ChildrenDefinitions.Add(ConfigWizardDefinition);
                wizard.ChildrenDefinitions.Add(HermesWizardDefinition);
                WizardCollection collection = new WizardCollection();
                collection.WizardDefinitions.Add(wizard);

                workflowDesignApi.Wizards.Register(collection);
                Initialize(workflowDesignApi);

            }
            catch (Exception ex)
            {
                MessageBox.Show(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Initialize(IWorkflowDesignApi API)
        {
            MessageBox.Show("Initialize");
            API.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationsFilePathKey, out var configPath);
            API.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationTypesFilePathKey, out var classesPath);

            Services = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .AddSingleton<IHermesService>(HermesService)
                .AddSingleton<IWorkflowDesignApi>(API)
                .AddSingleton<ITypeParserService>(new TypeParserService())
                .AddSingleton<OrchestratorService>(OrchestratorService)
                .AddSingleton(services => new ConfigurationService(services))
                .BuildServiceProvider();
            ConfigurationService = Services.GetRequiredService<ConfigurationService>();
            MessageBox.Show(JsonConvert.SerializeObject(OrchestratorService, Formatting.Indented));
            MessageBox.Show($"Config wizards initialized with project: '{JsonConvert.SerializeObject(ConfigurationService.Project)}'");


        }

        public static Activity RunConfig()
        {
            try
            {
                MessageBox.Show("RunConfig");
                ConfigurationService.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return null;
        }

        public static Activity RunHermes()
        {
            try
            {
                MessageBox.Show("RunHermes");
                HermesService.ShowHermesWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return null;
        }
    }
}
