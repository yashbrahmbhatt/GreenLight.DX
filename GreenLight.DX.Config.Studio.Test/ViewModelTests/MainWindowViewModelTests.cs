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
using GreenLight.DX.Config.Studio.Test.Mocks;
using Microsoft.Extensions.DependencyInjection;
using GreenLight.DX.Config.Studio.ViewModels;
using GreenLight.DX.Config.Shared.Models;

namespace GreenLight.DX.Config.Studio.Test.ViewModelTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private MockServices mockServices;
        private MainWindowViewModel viewModel;
        private Project model;
        private IServiceProvider serviceProvider;

        [TestInitialize]
        public void Setup()
        {
            mockServices = new MockServices();
            model = new Project();
            serviceProvider = mockServices.ServiceProvider.Object;
            viewModel = new MainWindowViewModel(serviceProvider, model);
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
            var configModel = new Configuration { Name = "ToDelete" };
            model.Configurations.Add(configModel);
            var configViewModel = viewModel.Configurations.FirstOrDefault(c => c.Model == configModel);
            Assert.IsNotNull(configViewModel);
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

            mockServices.AssetApiService.Setup(api => api.GetAssetFolders(It.IsAny<int>()))
                .ReturnsAsync(folders);
            mockServices.AssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder1"))
                .ReturnsAsync(assets1);
            mockServices.AssetApiService.Setup(api => api.GetAssets(It.IsAny<AssetRequestParameters>(), "Folder2"))
                .ReturnsAsync(assets2);

            await ((dynamic)viewModel.LoadAssetsCommand).ExecuteAsync(null);

            Assert.AreEqual(2, viewModel.AssetsMap.Count);
            Assert.AreEqual("Folder1", viewModel.AssetsMap[0].Key);
            Assert.AreEqual(assets1, viewModel.AssetsMap[0].Value);
            Assert.AreEqual("Folder2", viewModel.AssetsMap[1].Key);
            Assert.AreEqual(assets2, viewModel.AssetsMap[1].Value);
            mockServices.BusyService.Verify(bs => bs.Begin(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task SaveConfigurationsToFile_SavesConfigurations()
        {
            var testModel = new Project
            {
                Configurations = new ObservableCollection<Configuration>
                {
                    new Configuration { Name = "TestConfig" }
                }
            };

            viewModel.Model = testModel;

            string filePath = "testConfig.json";
            mockServices.BusyService.Setup(bs => bs.Begin(It.IsAny<string>())).ReturnsAsync(mockServices.BusyScope.Object);

            await viewModel.SaveConfigurationsToFile(filePath);

            Assert.IsTrue(File.Exists(filePath));
            var savedJson = File.ReadAllText(filePath);
            var savedModel = JsonConvert.DeserializeObject<Project>(savedJson);
            Assert.AreEqual(testModel.Configurations[0].Name, savedModel.Configurations[0].Name);
            File.Delete(filePath);
        }

        [TestMethod]
        public async Task LoadConfigurationFromFile_LoadsConfigurations()
        {
            var testModel = new Project
            {
                Configurations = new ObservableCollection<Configuration>
                {
                    new Configuration { Name = "TestConfig" }
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
            var configModel = new Configuration { Name = "TestClass" };
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
            model.Configurations.Add(new Configuration { Name = "Duplicate" });
            model.Configurations.Add(new Configuration { Name = "Duplicate" });
            viewModel.InitializeConfigurations();

            Assert.IsTrue(viewModel.Configurations[0].HasErrors);
            Assert.IsTrue(viewModel.Configurations[1].HasErrors);
        }

        [TestMethod]
        public void ValidateUniqueNames_RemovesErrorForUniqueNames()
        {
            model.Configurations.Add(new Configuration { Name = "Unique1" });
            model.Configurations.Add(new Configuration { Name = "Unique2" });
            viewModel.InitializeConfigurations();

            Assert.IsFalse(viewModel.Configurations[0].HasErrors);
            Assert.IsFalse(viewModel.Configurations[1].HasErrors);
        }

        [TestMethod]
        public void OnPropertyChanged_CallsValidateUniqueNames()
        {
            model.Configurations.Add(new Configuration { Name = "Duplicate" });
            model.Configurations.Add(new Configuration { Name = "Duplicate" });
            //viewModel.InitializeConfigurations();

            viewModel.Namespace = "NewNamespace";

            Assert.IsTrue(viewModel.Configurations[0].HasErrors);
            Assert.IsTrue(viewModel.Configurations[1].HasErrors);
        }
    }
}