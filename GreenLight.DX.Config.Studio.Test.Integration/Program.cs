using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Models;
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

namespace GreenLight.DX.Config.Studio.Test.Integration
{
    public static class Program
    {
        [STAThread] // Ensure STA mode for WPF
        public static void Main(string[] args)
        {
            var mockEventAggregator = new Mock<IEventAggregator>();
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockWorkflowDesignApi = new Mock<IWorkflowDesignApi>();
            var mockOrchestratorApiService = new Mock<IOrchestratorApiService>();
            var mockAssetApiService = new Mock<IAssetApiService>();
            var mockProjectPropertiesService = new Mock<IProjectPropertiesService>();
            var mockHermesService = new Mock<IHermesService>();
            var mockBusyService = new Mock<IStudioBusyService>();
            var mockBusyScope = new Mock<IStudioBusyScope>();

            var mockConfigDeletedEvent = new Mock<ConfigurationDeletedEvent>();
            var mockSettingRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<SettingRowModel>>();
            var mockAssetRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<AssetRowModel>>();
            var mockResourceRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<ResourceRowModel>>();
            var mockSettingRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<SettingRowModel>>();
            var mockAssetRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<AssetRowModel>>();
            var mockResourceRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<ResourceRowModel>>();

            mockBusyScope.Setup(bs => bs.SetStatus(It.IsAny<string>())).Returns(Task.CompletedTask);
            mockBusyScope.Setup(bs => bs.DisposeAsync()).Returns(ValueTask.CompletedTask);
            mockBusyService.Setup(bs => bs.Begin(It.IsAny<string>())).ReturnsAsync(mockBusyScope.Object);

            mockServiceProvider.Setup(sp => sp.GetService(typeof(IEventAggregator))).Returns(mockEventAggregator.Object);
            mockServiceProvider.Setup(sp => sp.GetService(typeof(IWorkflowDesignApi))).Returns(mockWorkflowDesignApi.Object);
            mockServiceProvider.Setup(sp => sp.GetService(typeof(IHermesService))).Returns(mockHermesService.Object);

            mockWorkflowDesignApi.Setup(api => api.OrchestratorApiService).Returns(mockOrchestratorApiService.Object);
            mockWorkflowDesignApi.Setup(api => api.ProjectPropertiesService).Returns(mockProjectPropertiesService.Object);
            mockWorkflowDesignApi.Setup(api => api.BusyService).Returns(mockBusyService.Object);

            mockOrchestratorApiService.Setup(api => api.AssetApiService).Returns(mockAssetApiService.Object);
            mockOrchestratorApiService.Setup(api => api.AssetApiService).Returns(mockAssetApiService.Object);

            mockAssetApiService.Setup(api => api.GetAssetFolders(It.IsAny<int>())).ReturnsAsync(new List<string>() { "Folder1", "Folder2" });
            mockAssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder1")).ReturnsAsync(new List<string>() { "Asset1", "Asset2" });
            mockAssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder2")).ReturnsAsync(new List<string>() { "Asset3", "Asset4" });

            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationDeletedEvent>()).Returns(mockConfigDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<SettingRowModel>>()).Returns(mockSettingRowDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<AssetRowModel>>()).Returns(mockAssetRowDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<ResourceRowModel>>()).Returns(mockResourceRowDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<SettingRowModel>>()).Returns(mockSettingRowPropertyChangedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<AssetRowModel>>()).Returns(mockAssetRowPropertyChangedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceRowModel>>()).Returns(mockResourceRowPropertyChangedEvent.Object);


            var model = new ProjectModel();
            var viewModel = new MainWindowViewModel(mockServiceProvider.Object, model);

            var app = new Application();
            var hermes = new HermesService(app.Dispatcher);
            var services = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .AddSingleton<IWorkflowDesignApi>(mockWorkflowDesignApi.Object)
                .AddSingleton<IHermesService>(hermes)
                .BuildServiceProvider();



            var window = new MainWindow(services, new MainWindowViewModel(services, new Models.ProjectModel()));
            //var window = new ConfigurationWindow();

            app.Run(window); // Starts the WPF message loop
        }

        

    }
}
