using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.Test.ViewModelTests
{
    [TestClass]
    public class ResourceRowViewModelTests
    {
        private IServiceProvider serviceProvider;
        private ResourceItem model;
        private ResourceRowViewModel viewModel;

        [TestInitialize]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider();
            model = new ResourceItem();
            viewModel = new ResourceRowViewModel(serviceProvider, model, 1);
        }

        [TestMethod]
        public void Constructor_InitializesSupportedTypes()
        {
            // Assert
            Assert.IsNotNull(viewModel.SupportedTypes);
            Assert.AreEqual(3, viewModel.SupportedTypes.Count);
            Assert.IsTrue(viewModel.SupportedTypes.Contains(typeof(string)));
            Assert.IsTrue(viewModel.SupportedTypes.Contains(typeof(System.Data.DataTable)));
            Assert.IsTrue(viewModel.SupportedTypes.Contains(typeof(System.Data.DataSet)));
        }

        [TestMethod]
        public void Path_Set_RaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Path))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.Path = "NewPath";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewPath", model.Path);
        }

        [TestMethod]
        public void Folder_Set_RaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Folder))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.Folder = "NewFolder";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewFolder", model.Folder);
        }

        [TestMethod]
        public void Bucket_Set_RaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Bucket))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.Bucket = "NewBucket";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewBucket", model.Bucket);
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
            eventAggregator.GetEvent<ConfigurationRowDeletedEvent<ResourceItem>>().Subscribe((vm) => { publishedEvent = true; });

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
            eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<ResourceItem>>().Subscribe((args) => { publishedEvent = true; });

            // Act
            viewModel.Key = "TestKey";

            // Assert
            Assert.IsTrue(publishedEvent);
        }
    }
}
