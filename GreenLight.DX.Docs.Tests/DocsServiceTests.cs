using GreenLight.DX.Docs.Project;
using GreenLight.DX.Docs.Xaml;
using GreenLight.DX.Hermes.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
namespace GreenLight.DX.Docs.Tests
{
    [STATestClass]
    public class DocsServiceTests
    {
        private DocsSettings _settings = new DocsSettings()
        {
            IgnoredPaths = new() { ".local" },
            OutputRoot = "C:\\Users\\yash.brahmbhatt\\Downloads\\Documentation",
            ProjectName = "LazyFramework",
            ProjectRoot = "C:\\Users\\yash.brahmbhatt\\Documents\\UiPath\\DocsTest",
            TemplatesRoot = "C:\\Users\\yash.brahmbhatt\\Documents\\UiPath\\DocsTest\\.docs"
        };
        private DocsService _service { get; set; }
        private IServiceProvider _serviceProvider { get; set; }

        [TestInitialize]
        public async Task TestInitialize()
        {
            var hermes = new HermesService(Dispatcher.CurrentDispatcher);
            _serviceProvider = new ServiceCollection().AddSingleton<IHermesService>(hermes).BuildServiceProvider();
            _service = new DocsService(_settings, _serviceProvider);
        }

        [TestMethod]
        public async Task ProjectLoaded()
        {
            Assert.IsNotNull(_service.ProjectEditor);
        }

        [STATestMethod]
        public async Task ShowHermes()
        {
            _serviceProvider.GetRequiredService<IHermesService>().ShowHermesWindow();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task Document()
        {
            _service.Document();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clean up the service provider
            (_serviceProvider as IDisposable)?.Dispose();
        }
    }
}
