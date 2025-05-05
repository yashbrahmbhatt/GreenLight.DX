using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
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

namespace GreenLight.DX.Config.Wizards.Configuration.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel Model { get; set; }
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            viewModel.CloseWindowAction = Close;
            Model = viewModel;
            DataContext = Model;
        }
    }
}
