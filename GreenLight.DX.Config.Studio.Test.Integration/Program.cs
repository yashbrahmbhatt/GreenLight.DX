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
            //var mockServices = new MockServices();
            //var model = new Shared.Models.Project();
            ////var viewModel = new MainWindowViewModel(mockServices.ServiceProvider.Object, model);

            //var app = new Application();
            //var hermes = new HermesService(app.Dispatcher);
            //var services = new ServiceCollection()
            //    .AddSingleton<IEventAggregator>(new EventAggregator())
            //    .AddSingleton<IWorkflowDesignApi>(mockServices.WorkflowDesignApi.Object)
            //    .AddSingleton<IHermesService>(hermes)
            //    .AddSingleton<ITypeParserService>(new TypeParserService())
            //    .AddSingleton<ConfigurationService>(services => new ConfigurationService(services))
            //    .BuildServiceProvider();

            //var window = new MainWindow(services, new MainWindowViewModel(services));

            //app.Run(window); // Starts the WPF message loop
        }
    }
}