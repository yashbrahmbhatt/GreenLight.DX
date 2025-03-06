using GreenLight.DX.Shared.Commands;
using GreenLight.DX.Shared.Hermes.ViewModels;
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
using UiPath.Studio.Api.Theme;

namespace GreenLight.DX.Shared.Hermes.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HermesWindow : Window
    {
        public HermesWindowViewModel ViewModel { get; }

        public HermesWindow(HermesWindowViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;

            ViewModel.RefreshDisplay(); // Call RefreshDisplay after window is loaded

            //ViewModel.RefreshDisplay(); // Initial display
            //Loaded += Window_Loaded; // Subscribe to Loaded event
        }
    }
}
