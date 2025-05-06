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

namespace GreenLight.DX.Config.Wizards
{
    public static class Wizard
    {
        public static IServiceProvider Services { get; set; }

        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            MessageBox.Show("Create");
            try
            {
                var hermes = new HermesService(Application.Current.Dispatcher);
                Services = new ServiceCollection()
                    .AddSingleton<IEventAggregator>(new EventAggregator())
                    .AddSingleton<IHermesService>(hermes)
                    .AddSingleton<IWorkflowDesignApi>(workflowDesignApi)
                    .AddSingleton<ITypeParserService>(new TypeParserService())
                    .AddSingleton<ConfigurationService>(services => new ConfigurationService(services))
                    .BuildServiceProvider();
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
                Initialize();

            }
            catch (Exception ex)
            {
                MessageBox.Show(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Initialize()
        {
            MessageBox.Show("Initialize");
            var API = Services.GetService<IWorkflowDesignApi>() ?? throw new NullReferenceException($"WorkflowAPI was null");
            var configService = Services.GetService<ConfigurationService>() ?? throw new NullReferenceException($"ConfigurationService was null");
            MessageBox.Show("Loaded Services");
            API.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationsFilePathKey, out var configPath);
            API.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationTypesFilePathKey, out var classesPath);
            MessageBox.Show("Settings queried");

            if (configPath == null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    FilterIndex = 1,
                    FileName = "Configurations.json",
                    InitialDirectory = API.ProjectPropertiesService.GetProjectDirectory(),
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    configPath = Path.GetRelativePath(API.ProjectPropertiesService.GetProjectDirectory(), saveFileDialog.FileName);
                }
                else
                {
                    configPath = "Configurations.json";
                }
                API.Settings.TrySetValue(SettingKeys.Config_ConfigurationsFilePathKey, configPath);
            }
            if (classesPath == null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "C# files (*.cs)|*.cs",
                    FilterIndex = 1,
                    FileName = "ConfigurationTypes.cs",
                    InitialDirectory = API.ProjectPropertiesService.GetProjectDirectory(),
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    classesPath = Path.GetRelativePath(API.ProjectPropertiesService.GetProjectDirectory(), saveFileDialog.FileName);
                }
                else
                {
                    classesPath = "ConfigurationTypes.cs";
                }
                API.Settings.TrySetValue(SettingKeys.Config_ConfigurationTypesFilePathKey, classesPath);
            }
            MessageBox.Show("Config wizards initialized");
        }

        public static Activity Run()
        {
            try
            {
                MessageBox.Show("Running");
                var viewModel = new MainWindowViewModel(Services);
                var window = new MainWindow(viewModel);
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
