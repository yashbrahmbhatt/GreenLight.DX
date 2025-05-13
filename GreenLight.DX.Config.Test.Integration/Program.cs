using GreenLight.DX.Config.Services.Configuration;
using GreenLight.DX.Config.Services.TypeParser;
using GreenLight.DX.Config.Settings;
using GreenLight.DX.Config.Tests.Integration;
using GreenLight.DX.Hermes.Services;
using GreenLight.DX.Shared.Services.Orchestrator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.BusyService;
using UiPath.Studio.Activities.Api.ProjectProperties;

namespace GreenLight.DX.Config.Studio.Test.Integration
{
    public static class Program
    {

        [STAThread] // Ensure STA mode for WPF
        public static void Main(string[] args)
        {
            var app = new Application();

            var _baseUrl = "https://cloud.uipath.com/yourorgname"; // Replace with your Orchestrator URL
            var _clientId = "yourClientId";        // Replace with your Client ID
            var _clientSecret = "yourClientSecret";    // Replace with your Client Secret

            var hermes = new HermesService(app.Dispatcher);
            var orch = new OrchestratorService(_baseUrl, _clientId, _clientSecret);
            var api = new MockWorkflowDesignApi();
            api.Settings.TrySetValue(SettingKeys.Config_ConfigurationsFilePathKey, "C:\\Users\\yash.brahmbhatt\\Downloads\\.config\\Configurations.json");
            api.Settings.TrySetValue(SettingKeys.Config_ConfigurationTypesFilePathKey, "C:\\Users\\yash.brahmbhatt\\Downloads\\.config\\ConfigurationTypes.cs");
            api.Settings.TrySetValue(SettingKeys.Config_ConfigurationTypesNamespaceKey, "Configurations");
            var services = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .AddSingleton<IHermesService>(hermes)
                .AddSingleton<ITypeParserService>(new TypeParserService())
                .AddSingleton<OrchestratorService>(orch)
                .AddSingleton<IWorkflowDesignApi>(api)
                .AddSingleton(services => new ConfigurationService(services))
                .BuildServiceProvider();

            var config = services.GetService<ConfigurationService>();
            hermes.ShowHermesWindow();
            app.Dispatcher.Invoke(() => config?.Show());
            app.Run();
        }
    }
}