using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Models;
using GreenLight.DX.Config.Studio.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.Test.ViewModelTests
{
    [TestClass]
    public class ConfigurationViewModelTests
    {
        private IServiceProvider serviceProvider;
        private ConfigurationModel model;
        private ConfigurationViewModel viewModel;
        private ObservableCollection<KeyValuePair<string, IEnumerable<string>>> assetsMap;

        [TestInitialize]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider();
            model = new ConfigurationModel();
            assetsMap = new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
            {
                new KeyValuePair<string, IEnumerable<string>>("Folder1", new List<string>() { "Asset1", "Asset2", "Asset3" }),
                new KeyValuePair<string, IEnumerable<string>>("Folder2", new List<string>() { "Asset4", "Asset5", "Asset6" }),
                new KeyValuePair<string, IEnumerable<string>>("Folder3", new List<string>() { "Asset7", "Asset8", "Asset9" }),
            };
            viewModel = new ConfigurationViewModel(serviceProvider, model, assetsMap);
        }

        [TestMethod]
        public void Constructor_InitializesCollectionsAndCommands()
        {
            Assert.IsNotNull(viewModel.Settings);
            Assert.IsNotNull(viewModel.Assets);
            Assert.IsNotNull(viewModel.Resources);
            Assert.IsNotNull(viewModel.AddSettingsRowCommand);
            Assert.IsNotNull(viewModel.AddAssetsRowCommand);
            Assert.IsNotNull(viewModel.AddResourcesRowCommand);
            Assert.IsNotNull(viewModel.EditConfigurationCommand);
            Assert.IsNotNull(viewModel.DeleteConfigurationCommand);
            Assert.IsNotNull(viewModel.FolderNames);
            Assert.IsTrue(viewModel.FolderNames.SequenceEqual(assetsMap.Select(a => a.Key)));
        }

        [TestMethod]
        public void Name_Set_RaisesPropertyChangedAndValidates()
        {
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Name))
                {
                    propertyChangedRaised = true;
                }
            };
            viewModel.Name = "NewName";
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewName", model.Name);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public void Name_Set_AddsErrorWhenEmpty()
        {
            viewModel.Name = "";
            Assert.IsTrue(viewModel.HasErrors);
            Assert.IsTrue(viewModel.GetErrors(nameof(viewModel.Name)).Cast<string>().Any());
        }

        [TestMethod]
        public void Description_Set_RaisesPropertyChangedAndValidates()
        {
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Description))
                {
                    propertyChangedRaised = true;
                }
            };
            viewModel.Description = "NewDescription";
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewDescription", model.Description);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public async Task AddSettingsRowCommand_Execute_AddsSettingRow()
        {
            await ((dynamic)viewModel.AddSettingsRowCommand).ExecuteAsync(null);
            Assert.AreEqual(1, viewModel.Settings.Count);
            Assert.AreEqual(1, model.Settings.Count);
        }

        [TestMethod]
        public async Task AddAssetsRowCommand_Execute_AddsAssetRow()
        {
            await ((dynamic)viewModel.AddAssetsRowCommand).ExecuteAsync(null);
            Assert.AreEqual(1, viewModel.Assets.Count);
            Assert.AreEqual(1, model.Assets.Count);
        }

        [TestMethod]
        public async Task AddResourcesRowCommand_Execute_AddsResourceRow()
        {
            await ((dynamic)viewModel.AddResourcesRowCommand).ExecuteAsync(null);
            Assert.AreEqual(1, viewModel.Resources.Count);
            Assert.AreEqual(1, model.Resources.Count);
        }

        [TestMethod]
        public async Task DeleteConfigurationCommand_Execute_PublishesEvent()
        {
            var eventAggregator = serviceProvider.GetRequiredService<IEventAggregator>();
            var publishedEvent = false;
            eventAggregator.GetEvent<ConfigurationDeletedEvent>().Subscribe((vm) => { publishedEvent = true; });
            await ((dynamic)viewModel.DeleteConfigurationCommand).ExecuteAsync(null);
            Assert.IsTrue(publishedEvent);
        }

        [TestMethod]
        public void Model_Settings_CollectionChanged_AddsViewModel()
        {
            var newSetting = new SettingRowModel();
            model.Settings.Add(newSetting);
            Assert.AreEqual(1, viewModel.Settings.Count);
        }

        [TestMethod]
        public void Model_Assets_CollectionChanged_AddsViewModel()
        {
            var newAsset = new AssetRowModel();
            model.Assets.Add(newAsset);
            Assert.AreEqual(1, viewModel.Assets.Count);
        }

        [TestMethod]
        public void Model_Resources_CollectionChanged_AddsViewModel()
        {
            var newResource = new ResourceRowModel();
            model.Resources.Add(newResource);
            Assert.AreEqual(1, viewModel.Resources.Count);
        }

        [TestMethod]
        public void OnConfigurationRowDeleted_RemovesViewModel()
        {
            var settingViewModel = new SettingRowViewModel(serviceProvider, new SettingRowModel(), 1);
            model.Settings.Add(settingViewModel.Model);
            viewModel.OnConfigurationRowDeleted(settingViewModel);
            Assert.AreEqual(0, viewModel.Settings.Count);
            Assert.AreEqual(0, model.Settings.Count);
        }

        [TestMethod]
        public void ValidateUniqueKeys_AddsErrorsForDuplicates()
        {
            var setting1Model = new SettingRowModel { Key = "DuplicateKey" };
            var setting2Model = new SettingRowModel { Key = "DuplicateKey" };
            model.Settings.Add(setting1Model);
            model.Settings.Add(setting2Model);
            viewModel.ValidateUniqueKeys();
            Assert.IsTrue(viewModel.Settings[0].HasErrors);
            Assert.IsTrue(viewModel.Settings[1].HasErrors);
        }

        [TestMethod]
        public void AssetsMap_CollectionChanged_UpdatesFolderNames()
        {
            var newAssetsMap = new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
            {
                new KeyValuePair<string, IEnumerable<string>>("NewFolder", new List<string>() { "NewAsset" }),
            };
            viewModel.AssetsMap.Clear();
            foreach (var kvp in newAssetsMap) viewModel.AssetsMap.Add(kvp);
            Assert.IsTrue(viewModel.FolderNames.SequenceEqual(newAssetsMap.Select(a => a.Key)));
        }
    }
}
