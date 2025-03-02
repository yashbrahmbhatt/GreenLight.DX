using GreenLight.DX.ViewModels;
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

namespace GreenLight.DX.Windows
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationViewModel ViewModel { get; set; } = new ConfigurationViewModel();
        public ConfigurationWindow()
        {
            DataContext = ViewModel;
            InitializeComponent();
        }

        public ConfigurationWindow(ConfigurationViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
