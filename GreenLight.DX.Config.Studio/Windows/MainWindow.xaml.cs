using GreenLight.DX.Config.Studio.Misc;
using GreenLight.DX.Config.Studio.ViewModels;
using GreenLight.DX.Shared.Hermes.Services;
using GreenLight.DX.Shared.Hermes.ViewModels;
using GreenLight.DX.Shared.Hermes.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Studio.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHermesService _logger;
        private static readonly string _logContext = "MainWindow";
        private void Log(string message) => _logger.Info(_logContext, message);

        public MainWindowViewModel Model { get; set; }
        public MainWindow(ServiceProvider services, MainWindowViewModel viewModel)
        {
            InitializeComponent();
            _logger = services.GetRequiredService<IHermesService>();
            Log("Initializing window");
            viewModel.CloseWindowAction = Close;
            Model = viewModel;
            DataContext = Model;
            Log("Initialized window");
        }
    }
}
