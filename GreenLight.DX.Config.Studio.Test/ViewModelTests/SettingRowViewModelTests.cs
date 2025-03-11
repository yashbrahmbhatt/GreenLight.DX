using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Misc;
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
    public class SettingRowViewModelTests
    {
        private IServiceProvider serviceProvider;
        private SettingRowModel model;
        private SettingRowViewModel viewModel;

        [TestInitialize]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IEventAggregator>(new EventAggregator())
                .BuildServiceProvider();
            model = new SettingRowModel();
            viewModel = new SettingRowViewModel(serviceProvider, model, 1);
        }

        [TestMethod]
        public void Constructor_InitializesSupportedTypes()
        {
            // Arrange (already done in Setup)

            // Act (already done in Setup)

            // Assert
            Assert.IsNotNull(viewModel.SupportedTypes);
            Assert.IsTrue(viewModel.SupportedTypes.SequenceEqual(TypeParsers.Parsers.Keys));
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
        public void Value_Set_RaisesPropertyChangedAndValidates()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.Value))
                {
                    propertyChangedRaised = true;
                }
            };

            // Act
            viewModel.Value = "NewValue";

            // Assert
            Assert.IsTrue(propertyChangedRaised);
            Assert.AreEqual("NewValue", model.Value);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public void Value_Set_AddsErrorWhenEmpty()
        {
            // Act
            viewModel.Value = "";

            // Assert
            Assert.IsTrue(viewModel.HasErrors);
            Assert.IsTrue(viewModel.GetErrors("Value").Cast<string>().Any());
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
            Assert.AreEqual(typeof(int), model.SelectedType);
            Assert.IsFalse(viewModel.HasErrors);
        }

        [TestMethod]
        public void BaseClass_DeleteRowCommand_Execute_PublishesEvent()
        {
            // Arrange
            var eventAggregator = serviceProvider.GetRequiredService<IEventAggregator>();
            var publishedEvent = false;
            eventAggregator.GetEvent<ConfigurationRowDeletedEvent<SettingRowModel>>().Subscribe((vm) => { publishedEvent = true; });

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
            eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<SettingRowModel>>().Subscribe((args) => { publishedEvent = true; });

            // Act
            viewModel.Key = "TestKey";

            // Assert
            Assert.IsTrue(publishedEvent);
        }
    }
}
