using GreenLight.DX.Config.Studio.Models;
using GreenLight.DX.Config.Studio.ViewModels;
using GreenLight.DX.Shared.Hermes.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using System;
using System.Activities.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.ProjectProperties;
using UiPath.Studio.Activities.Api;
using GreenLight.DX.Config.Studio.Events;
using UiPath.Studio.Activities.Api.BusyService;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace GreenLight.DX.Config.Studio.Test.ViewModelTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private Mock<IEventAggregator> mockEventAggregator;
        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IWorkflowDesignApi> mockWorkflowDesignApi;
        private Mock<IOrchestratorApiService> mockOrchestratorApiService;
        private Mock<IAssetApiService> mockAssetApiService;
        private Mock<IProjectPropertiesService> mockProjectPropertiesService;
        private Mock<IHermesService> mockHermesService;
        private Mock<IStudioBusyService> mockBusyService;
        private Mock<IStudioBusyScope> mockBusyScope;

        private Mock<ConfigurationDeletedEvent> mockConfigDeletedEvent;
        private Mock<ConfigurationRowDeletedEvent<SettingRowModel>> mockSettingRowDeletedEvent;
        private Mock<ConfigurationRowDeletedEvent<AssetRowModel>> mockAssetRowDeletedEvent;
        private Mock<ConfigurationRowDeletedEvent<ResourceRowModel>> mockResourceRowDeletedEvent;
        private Mock<ConfigurationRowPropertyChangedEvent<SettingRowModel>> mockSettingRowPropertyChangedEvent;
        private Mock<ConfigurationRowPropertyChangedEvent<AssetRowModel>> mockAssetRowPropertyChangedEvent;
        private Mock<ConfigurationRowPropertyChangedEvent<ResourceRowModel>> mockResourceRowPropertyChangedEvent;

        private MainWindowViewModel viewModel;
        private ProjectModel model;

        [TestInitialize]
        public void Setup()
        {
            mockEventAggregator = new Mock<IEventAggregator>();
            mockServiceProvider = new Mock<IServiceProvider>();
            mockWorkflowDesignApi = new Mock<IWorkflowDesignApi>();
            mockOrchestratorApiService = new Mock<IOrchestratorApiService>();
            mockAssetApiService = new Mock<IAssetApiService>();
            mockProjectPropertiesService = new Mock<IProjectPropertiesService>();
            mockHermesService = new Mock<IHermesService>();
            mockBusyService = new Mock<IStudioBusyService>();
            mockBusyScope = new Mock<IStudioBusyScope>();

            mockConfigDeletedEvent = new Mock<ConfigurationDeletedEvent>();
            mockSettingRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<SettingRowModel>>();
            mockAssetRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<AssetRowModel>>();
            mockResourceRowDeletedEvent = new Mock<ConfigurationRowDeletedEvent<ResourceRowModel>>();
            mockSettingRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<SettingRowModel>>();
            mockAssetRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<AssetRowModel>>();
            mockResourceRowPropertyChangedEvent = new Mock<ConfigurationRowPropertyChangedEvent<ResourceRowModel>>();

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

            mockAssetApiService.Setup(api => api.GetAssetFolders(It.IsAny<int>())).ReturnsAsync(new List<string>() { "Folder1", "Folder2"});
            mockAssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder1")).ReturnsAsync(new List<string>() { "Asset1", "Asset2" });
            mockAssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder2")).ReturnsAsync(new List<string>() { "Asset3", "Asset4" });

            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationDeletedEvent>()).Returns(mockConfigDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<SettingRowModel>>()).Returns(mockSettingRowDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<AssetRowModel>>()).Returns(mockAssetRowDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowDeletedEvent<ResourceRowModel>>()).Returns(mockResourceRowDeletedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<SettingRowModel>>()).Returns(mockSettingRowPropertyChangedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<AssetRowModel>>()).Returns(mockAssetRowPropertyChangedEvent.Object);
            mockEventAggregator.Setup(ea => ea.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceRowModel>>()).Returns(mockResourceRowPropertyChangedEvent.Object);


            model = new ProjectModel();
            viewModel = new MainWindowViewModel(mockServiceProvider.Object, model);
        }

        [TestMethod]
        public void Constructor_InitializesCollectionsAndCommands()
        {
            Assert.IsNotNull(viewModel.Configurations);
            Assert.IsNotNull(viewModel.AddConfigurationCommand);
            Assert.IsNotNull(viewModel.SaveConfigurationsCommand);
            Assert.IsNotNull(viewModel.LoadConfigurationsCommand);
            Assert.IsNotNull(viewModel.WriteConfigClassesCommand);
            Assert.IsNotNull(viewModel.ExitCommand);
            Assert.IsNotNull(viewModel.LoadAssetsCommand);
            Assert.IsNotNull(viewModel.OpenAboutCommand);
            Assert.IsNotNull(viewModel.OpenHermesCommand);
            Assert.IsNotNull(viewModel.AssetsMap);
        }

        [TestMethod]
        public void Namespace_Set_RaisesPropertyChangedAndUpdatesModel()
        {
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Namespace))
                {
                    propertyChangedRaised = true;
                }
            };
            viewModel.Namespace = "NewNamespace";
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewNamespace", model.Namespace);
        }

        [TestMethod]
        public async Task OnAddConfiguration_AddsConfigurationToModelAndViewModel()
        {
            await ((dynamic)viewModel.AddConfigurationCommand).ExecuteAsync(null);
            Assert.AreEqual(1, viewModel.Configurations.Count);
            Assert.AreEqual(1, model.Configurations.Count);
            Assert.AreEqual("New Configuration", viewModel.Configurations[0].Name);
        }

        [TestMethod]
        public void OnConfigurationDeleted_RemovesConfigurationFromModelAndViewModel()
        {
            var configModel = new ConfigurationModel { Name = "ToDelete" };
            model.Configurations.Add(configModel);
            var configViewModel = viewModel.Configurations.FirstOrDefault(c => c.Model == configModel);
            Assert.IsNotNull(configViewModel);
            //mockConfigDeletedEvent.Setup(e => e.Publish(viewModel.Configurations[0]));
            viewModel.OnConfigurationDeleted(configViewModel);
            Assert.AreEqual(0, viewModel.Configurations.Count);
            Assert.AreEqual(0, model.Configurations.Count);
        }

        [TestMethod]
        public async Task LoadAssets_LoadsAssetsFromOrchestrator()
        {
            var folders = new List<string> { "Folder1", "Folder2" };
            var assets1 = new List<string> { "Asset1", "Asset2" };
            var assets2 = new List<string> { "Asset3", "Asset4" };

            mockAssetApiService.Setup(api => api.GetAssetFolders(It.IsAny<int>()))
                .ReturnsAsync(folders);
            mockAssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder1"))
                .ReturnsAsync(assets1);
            mockAssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder2"))
                .ReturnsAsync(assets2);

            await ((dynamic)viewModel.LoadAssetsCommand).ExecuteAsync(null);

            Assert.AreEqual(2, viewModel.AssetsMap.Count);
            Assert.AreEqual("Folder1", viewModel.AssetsMap[0].Key);
            Assert.AreEqual(assets1, viewModel.AssetsMap[0].Value);
            Assert.AreEqual("Folder2", viewModel.AssetsMap[1].Key);
            Assert.AreEqual(assets2, viewModel.AssetsMap[1].Value);
            mockBusyService.Verify(bs => bs.Begin(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task SaveConfigurationsToFile_SavesConfigurations()
        {
            var testModel = new ProjectModel
            {
                Configurations = new ObservableCollection<ConfigurationModel>
                {
                    new ConfigurationModel { Name = "TestConfig" }
                }
            };

            viewModel.Model = testModel;

            string filePath = "testConfig.json";
            mockBusyService.Setup(bs => bs.Begin(It.IsAny<string>())).ReturnsAsync(mockBusyScope.Object);

            await viewModel.SaveConfigurationsToFile(filePath);

            Assert.IsTrue(File.Exists(filePath));
            var savedJson = File.ReadAllText(filePath);
            var savedModel = JsonConvert.DeserializeObject<ProjectModel>(savedJson);
            Assert.AreEqual(testModel.Configurations[0].Name, savedModel.Configurations[0].Name);
            File.Delete(filePath);
        }

        [TestMethod]
        public async Task LoadConfigurationFromFile_LoadsConfigurations()
        {
            var testModel = new ProjectModel
            {
                Configurations = new ObservableCollection<ConfigurationModel>
                {
                    new ConfigurationModel { Name = "TestConfig" }
                }
            };
            string filePath = "testConfig.json";
            File.WriteAllText(filePath, JsonConvert.SerializeObject(testModel));

            await viewModel.LoadConfigurationFromFile(filePath);

            Assert.AreEqual(testModel.Configurations[0].Name, viewModel.Model.Configurations[0].Name);
            File.Delete(filePath);
        }

        [TestMethod]
        public async Task WriteClass_WritesClassToFile()
        {
            var configModel = new ConfigurationModel { Name = "TestClass" };
            string folderPath = "TestFolder";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            await viewModel.WriteClass(configModel, folderPath);

            string filePath = Path.Combine(folderPath, "TestClassConfig.cs");
            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        public void ValidateUniqueNames_AddsErrorForDuplicateNames()
        {
            model.Configurations.Add(new ConfigurationModel { Name = "Duplicate" });
            model.Configurations.Add(new ConfigurationModel { Name = "Duplicate" });
            viewModel.InitializeConfigurations();

            Assert.IsTrue(viewModel.Configurations[0].HasErrors);
            Assert.IsTrue(viewModel.Configurations[1].HasErrors);
        }

        [TestMethod]
        public void ValidateUniqueNames_RemovesErrorForUniqueNames()
        {
            model.Configurations.Add(new ConfigurationModel { Name = "Unique1" });
            model.Configurations.Add(new ConfigurationModel { Name = "Unique2" });
            viewModel.InitializeConfigurations();

            Assert.IsFalse(viewModel.Configurations[0].HasErrors);
            Assert.IsFalse(viewModel.Configurations[1].HasErrors);
        }

        [TestMethod]
        public void OnPropertyChanged_CallsValidateUniqueNames()
        {
            model.Configurations.Add(new ConfigurationModel { Name = "Duplicate" });
            model.Configurations.Add(new ConfigurationModel { Name = "Duplicate" });
            viewModel.InitializeConfigurations();

            viewModel.Namespace = "NewNamespace";

            Assert.IsTrue(viewModel.Configurations[0].HasErrors);
            Assert.IsTrue(viewModel.Configurations[1].HasErrors);
        }
    }

    public interface IFileWrapper
    {
        Task WriteAllTextAsync(string path, string contents);
        void WriteAllText(string path, string contents);
        Task<string> ReadAllTextAsync(string path);
    }
}
