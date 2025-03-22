using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Shared.Services;
using GreenLight.DX.Config.Studio.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.ProjectProperties;
using System.Collections.ObjectModel;

namespace GreenLight.DX.Shared.Test
{
    [TestClass]
    public class ConfigurationServiceTests
    {
        private Mock<IServiceProvider> _mockServiceProvider;
        private Mock<ITypeParserService> _mockTypeParserService;
        private Mock<IWorkflowDesignApi> _mockWorkflowDesignApi;
        private Mock<IProjectPropertiesService> _mockProjectPropertiesService;
        private ConfigurationService _configurationService;

        [TestInitialize]
        public void Setup()
        {
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockTypeParserService = new Mock<ITypeParserService>();
            _mockWorkflowDesignApi = new Mock<IWorkflowDesignApi>();
            _mockProjectPropertiesService = new Mock<IProjectPropertiesService>();

            _mockServiceProvider.Setup(s => s.GetService(typeof(IWorkflowDesignApi))).Returns(_mockWorkflowDesignApi.Object);
            _mockServiceProvider.Setup(s => s.GetService(typeof(ITypeParserService))).Returns(_mockTypeParserService.Object);
            _mockWorkflowDesignApi.Setup(api => api.ProjectPropertiesService).Returns(_mockProjectPropertiesService.Object);

            _mockProjectPropertiesService.Setup(pps => pps.GetProjectDirectory()).Returns(Path.GetTempPath());

            _configurationService = new ConfigurationService(_mockServiceProvider.Object);
        }

        [TestMethod]
        public void ReadConfigurations_ValidJson_ReturnsProject()
        {
            // Arrange
            var project = new Project
            {
                Namespace = "TestNamespace",
                Configurations = new System.Collections.ObjectModel.ObservableCollection<Configuration>
                {
                    new Configuration { Name = "TestConfig" }
                }
            };
            var json = JsonConvert.SerializeObject(project);
            File.WriteAllText(Path.Combine(Path.GetTempPath(), ConfigurationService.ConfigurationsFile), json);

            // Act
            var result = _configurationService.ReadConfigurations();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("TestNamespace", result.Namespace);
            Assert.AreEqual(1, result.Configurations.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReadConfigurations_InvalidJson_ThrowsException()
        {
            // Arrange
            File.WriteAllText(Path.Combine(Path.GetTempPath(), ConfigurationService.ConfigurationsFile), "Invalid JSON");

            // Act & Assert
            _configurationService.ReadConfigurations();
        }

        [TestMethod]
        public void SaveConfigurations_ValidProject_SavesJsonToFile()
        {
            // Arrange
            _configurationService.Project = new Project
            {
                Namespace = "TestNamespace",
                Configurations = new System.Collections.ObjectModel.ObservableCollection<Configuration>
                {
                    new Configuration { Name = "TestConfig" }
                }
            };

            // Act
            _configurationService.SaveConfigurations();

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(Path.GetTempPath(), ConfigurationService.ConfigurationsFile)));
            var savedJson = File.ReadAllText(Path.Combine(Path.GetTempPath(), ConfigurationService.ConfigurationsFile));
            Assert.AreEqual(JsonConvert.SerializeObject(_configurationService.Project), savedJson);
        }

        [TestMethod]
        public void WriteClasses_ValidProject_WritesCsFile()
        {
            // Arrange
            _configurationService.Project = new Project
            {
                Namespace = "TestNamespace",
                Configurations = new ObservableCollection<Configuration>
                {
                    new Configuration
                    {
                        Name = "TestConfig",
                        Settings = new ObservableCollection<SettingItem> { new SettingItem { Key = "TestSetting", ValueType = typeof(string) } }
                    }
                }
            };

            // Act
            _configurationService.WriteClasses();

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(Path.GetTempPath(), ConfigurationService.ClassesFile)));
            var writtenCode = File.ReadAllText(Path.Combine(Path.GetTempPath(), ConfigurationService.ClassesFile));
            Assert.IsTrue(writtenCode.Contains("public class TestConfigConfig"));
        }

        [TestMethod]
        public void LoadConfiguration_ValidConfig_ReturnsInstance()
        {
            // Arrange
            var config = new Configuration
            {
                Settings = new ObservableCollection<SettingItem>
                {
                    new SettingItem { Key = "TestProperty", Value = "TestValue", ValueType = typeof(string) }
                }
            };
            _mockTypeParserService.Setup(tps => tps.Parse("TestValue", typeof(string))).Returns("ParsedValue");

            // Act
            var result = _configurationService.LoadConfiguration<TestConfig>(config);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ParsedValue", result.TestProperty);
        }

        [TestMethod]
        public void LoadConfiguration_InvalidType_DoesNotSetProperty()
        {
            // Arrange
            var config = new Configuration
            {
                Settings = new ObservableCollection<SettingItem>
                {
                    new SettingItem { Key = "TestProperty", StringValue = "123", ValueType = typeof(int) }
                }
            };
            _mockTypeParserService.Setup(tps => tps.Parse("123", typeof(int))).Throws(new Exception());

            // Act
            var result = _configurationService.LoadConfiguration<TestConfig>(config);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.TestProperty);
        }

        [TestMethod]
        public void GetConfigTypes_ValidProject_ReturnsTypes()
        {
            // Arrange
            _configurationService.Project = new Project
            {
                Namespace = "TestNamespace",
                Configurations = new System.Collections.ObjectModel.ObservableCollection<Configuration>
                {
                    new Configuration { Name = "TestConfig" }
                }
            };

            // Act
            var result = _configurationService.GetConfigTypes();

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("TestNamespace.TestConfigConfig", result[0].FullName);
        }

        public class TestConfig
        {
            public string TestProperty { get; set; }
        }
    }
}