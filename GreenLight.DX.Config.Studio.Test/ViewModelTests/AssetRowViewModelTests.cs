using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Misc;
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
    public class AssetRowViewModelTests
    {
        private IServiceProvider serviceProvider;
        private AssetItem model;
        private AssetRowViewModel viewModel;
        private ObservableCollection<KeyValuePair<string, IEnumerable<string>>> assetsMap;

        [TestInitialize]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider();
            model = new AssetItem();
            assetsMap = new ObservableCollection<KeyValuePair<string, IEnumerable<string>>>()
            {
                new KeyValuePair<string, IEnumerable<string>>("Folder1", new List<string>() { "Asset1", "Asset2", "Asset3" }),
                new KeyValuePair<string, IEnumerable<string>>("Folder2", new List<string>() { "Asset4", "Asset5", "Asset6" }),
                new KeyValuePair<string, IEnumerable<string>>("Folder3", new List<string>() { "Asset7", "Asset8", "Asset9" }),
            };
            viewModel = new AssetRowViewModel(serviceProvider, model, 1, assetsMap);
        }

        [TestMethod]
        public void Constructor_InitializesSupportedTypesAndFolders()
        {
            // Assert
            Assert.IsNotNull(viewModel.SupportedTypes);
            //Assert.IsTrue(viewModel.SupportedTypes.SequenceEqual(TypeParsers.Parsers.Keys));
            Assert.IsNotNull(viewModel.AssetFolders);
            Assert.IsTrue(viewModel.AssetFolders.SequenceEqual(assetsMap.Select(x => x.Key)));
        }

        [TestMethod]
        public void SupportedTypes_Set_RaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.SupportedTypes))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.SupportedTypes = new ObservableCollection<Type>();

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [TestMethod]
        public void AssetName_Set_RaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.AssetName))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.AssetName = "NewAssetName";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewAssetName", model.AssetName);
        }

        [TestMethod]
        public void AssetFolder_Set_RaisesPropertyChangedAndRefreshesNames()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.AssetFolder))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.AssetFolder = "Folder2";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("Folder2", model.AssetFolder);
            Assert.IsTrue(viewModel.AssetNames.SequenceEqual(assetsMap.First(x => x.Key == "Folder2").Value));
        }

        [TestMethod]
        public void RefreshFolders_UpdatesAssetFolders()
        {
            // Arrange
            assetsMap.Add(new KeyValuePair<string, IEnumerable<string>>("NewFolder", new List<string>() { "NewAsset" }));

            // Act
            viewModel.RefreshFolders();

            // Assert
            Assert.IsTrue(viewModel.AssetFolders.SequenceEqual(assetsMap.Select(x => x.Key)));
        }

        [TestMethod]
        public void RefreshNames_UpdatesAssetNames()
        {
            // Act
            viewModel.AssetFolder = "Folder3";
            viewModel.RefreshNames();

            // Assert
            Assert.IsTrue(viewModel.AssetNames.SequenceEqual(assetsMap.First(x => x.Key == "Folder3").Value));
        }

        [TestMethod]
        public void OnFolderChanged_RefreshesNames()
        {
            // Act
            viewModel.AssetFolder = "Folder1";

            // Assert
            Assert.IsTrue(viewModel.AssetNames.SequenceEqual(assetsMap.First(x => x.Key == "Folder1").Value));
        }

        [TestMethod]
        public void BaseClass_Key_Set_RaisesPropertyChangedAndValidates()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Key))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.Key = "NewKey";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewKey", model.Key);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public void BaseClass_Description_Set_RaisesPropertyChangedAndValidates()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Description))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.Description = "NewDescription";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewDescription", model.Description);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public void BaseClass_SelectedType_Set_RaisesPropertyChangedAndValidates()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.SelectedType))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.SelectedType = typeof(int);

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual(typeof(int), model.ValueType);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public void BaseClass_DeleteRowCommand_Execute_PublishesEvent()
        {
            // Arrange
            var eventAggregator = serviceProvider.GetRequiredService<IEventAggregator>();
            var publishedEvent = false;
            eventAggregator.GetEvent<ConfigurationRowDeletedEvent<AssetItem>>().Subscribe((vm) => { publishedEvent = true; });

            // Act
            viewModel.DeleteRowCommand.Execute(null);

            // Assert
            Assert.IsTrue(publishedEvent);
        }

        [TestMethod]
        public void BaseClass_OnPropertyChanged_Key_PublishesEvent()
        {
            // Arrange
            var eventAggregator = serviceProvider.GetRequiredService<IEventAggregator>();
            var publishedEvent = false;
            eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<AssetItem>>().Subscribe((args) => { publishedEvent = true; });

            // Act
            viewModel.Key = "TestKey";

            // Assert
            Assert.IsTrue(publishedEvent);
        }
    }
}
