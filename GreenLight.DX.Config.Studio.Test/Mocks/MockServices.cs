using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.ViewModels;
using GreenLight.DX.Shared.Hermes.Services;
using Moq;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.BusyService;
using UiPath.Studio.Activities.Api.ProjectProperties;
using UiPath.Studio.Activities.Api;
using GreenLight.DX.Config.Studio.Services;
using GreenLight.DX.Config.Shared.Models;

namespace GreenLight.DX.Config.Studio.Test.Mocks
{
    public class MockServices
    {
        public Mock<IEventAggregator> EventAggregator { get; }
        public Mock<IServiceProvider> ServiceProvider { get; }
        public Mock<IWorkflowDesignApi> WorkflowDesignApi { get; }
        public Mock<IOrchestratorApiService> OrchestratorApiService { get; }
        public Mock<IAssetApiService> AssetApiService { get; }
        public Mock<IProjectPropertiesService> ProjectPropertiesService { get; }
        public Mock<IHermesService> HermesService { get; }
        public Mock<IStudioBusyService> BusyService { get; }
        public Mock<IStudioBusyScope> BusyScope { get; }
        public Mock<ITypeParserService> TypeParserService { get; }

        public Mock<ConfigurationDeletedEvent> ConfigDeletedEvent { get; }
        public Mock<ConfigurationRowDeletedEvent<SettingItem>> SettingRowDeletedEvent { get; }
        public Mock<ConfigurationRowDeletedEvent<AssetItem>> AssetRowDeletedEvent { get; }
        public Mock<ConfigurationRowDeletedEvent<ResourceItem>> ResourceRowDeletedEvent { get; }
        public Mock<ConfigurationRowPropertyChangedEvent<SettingItem>> SettingRowPropertyChangedEvent { get; }
        public Mock<ConfigurationRowPropertyChangedEvent<AssetItem>> AssetRowPropertyChangedEvent { get; }
        public Mock<ConfigurationRowPropertyChangedEvent<ResourceItem>> ResourceRowPropertyChangedEvent { get; }
        public Mock<ConfigurationPropertyChangedEvent> ConfigurationPropertyChangedEvent { get; }

        public MockServices()
        {
            EventAggregator = new Mock<IEventAggregator>();
            ServiceProvider = new Mock<IServiceProvider>();
            WorkflowDesignApi = new Mock<IWorkflowDesignApi>();
            OrchestratorApiService = new Mock<IOrchestratorApiService>();
            AssetApiService = new Mock<IAssetApiService>();
            ProjectPropertiesService = new Mock<IProjectPropertiesService>();
            HermesService = new Mock<IHermesService>();
            BusyService = new Mock<IStudioBusyService>();
            BusyScope = new Mock<IStudioBusyScope>();
            TypeParserService = new Mock<ITypeParserService>();

            ConfigDeletedEvent = new Mock<ConfigurationDeletedEvent>();
            SettingRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<SettingItem>>();
            AssetRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<AssetItem>>();
            ResourceRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<ResourceItem>>();
            SettingRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<SettingItem>>();
            AssetRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<AssetItem>>();
            ResourceRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<ResourceItem>>();
            ConfigurationPropertyChangedEvent = new Mock<ConfigurationPropertyChangedEvent>();


            BusyScope.Setup(bs => bs.SetStatus(It.IsAny<string>())).Returns(Task.CompletedTask);
            BusyScope.Setup(bs => bs.DisposeAsync()).Returns(ValueTask.CompletedTask);
            BusyService.Setup(bs => bs.Begin(It.IsAny<string>())).ReturnsAsync(BusyScope.Object);

            ServiceProvider.Setup(sp => sp.GetService(typeof(IEventAggregator))).Returns(EventAggregator.Object);
            ServiceProvider.Setup(sp => sp.GetService(typeof(IWorkflowDesignApi))).Returns(WorkflowDesignApi.Object);
            ServiceProvider.Setup(sp => sp.GetService(typeof(IHermesService))).Returns(HermesService.Object);
            ServiceProvider.Setup(sp => sp.GetService(typeof(ITypeParserService))).Returns(new TypeParserService());

            WorkflowDesignApi.Setup(api => api.OrchestratorApiService).Returns(OrchestratorApiService.Object);
            WorkflowDesignApi.Setup(api => api.ProjectPropertiesService).Returns(ProjectPropertiesService.Object);
            WorkflowDesignApi.Setup(api => api.BusyService).Returns(BusyService.Object);

            OrchestratorApiService.Setup(api => api.AssetApiService).Returns(AssetApiService.Object);
            OrchestratorApiService.Setup(api => api.AssetApiService).Returns(AssetApiService.Object);


            AssetApiService.Setup(api => api.GetAssetFolders(It.IsAny<int>())).ReturnsAsync(new List<string>() { "Folder1", "Folder2" });
            AssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder1")).ReturnsAsync(new List<string>() { "Asset1", "Asset2" });
            AssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder2")).ReturnsAsync(new List<string>() { "Asset3", "Asset4" });

            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationDeletedEvent>()).Returns(ConfigDeletedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<SettingItem>>()).Returns(SettingRowDeletedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<AssetItem>>()).Returns(AssetRowDeletedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<ResourceItem>>()).Returns(ResourceRowDeletedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<SettingItem>>()).Returns(SettingRowPropertyChangedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<AssetItem>>()).Returns(AssetRowPropertyChangedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceItem>>()).Returns(ResourceRowPropertyChangedEvent.Object);
            EventAggregator.Setup(ea => ea.GetEvent<ConfigurationPropertyChangedEvent>()).Returns(ConfigurationPropertyChangedEvent.Object);
        }
    }
}