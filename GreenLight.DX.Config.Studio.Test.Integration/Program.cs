using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.ViewModels;
using GreenLight.DX.Config.Studio.Windows;
using GreenLight.DX.Shared.Hermes.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Windows;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.BusyService;
using UiPath.Studio.Activities.Api.ProjectProperties;
using GreenLight.DX.Config.Studio.Test.Mocks;
using Prism.Events;
using System.Threading.Tasks;
using GreenLight.DX.Config.Studio.Services;

namespace GreenLight.DX.Config.Studio.Test.Integration
{
    public static class Program
    {
        [STAThread] // Ensure STA mode for WPF
        public static void Main(string[] args)
        {
            var mockServices = new MockServices();
            var model = new Shared.Models.Project();
            var viewModel = new MainWindowViewModel(mockServices.ServiceProvider.Object, model);

            var app = new Application();
            var hermes = new HermesService(app.Dispatcher);
            var services = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .AddSingleton<IWorkflowDesignApi>(mockServices.WorkflowDesignApi.Object)
                .AddSingleton<IHermesService>(hermes)
                .AddSingleton<ITypeParserService>(new TypeParserService())
                .BuildServiceProvider();

            var window = new MainWindow(services, new MainWindowViewModel(services, model));

            app.Run(window); // Starts the WPF message loop
        }
    }
}