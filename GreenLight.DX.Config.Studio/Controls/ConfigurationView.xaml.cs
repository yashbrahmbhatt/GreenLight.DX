using GreenLight.DX.Config.Studio.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenLight.DX.Config.Studio.Controls
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>

    public partial class ConfigurationView : UserControl
    {
        public ConfigurationViewModel ViewModel { get; set; } = new ConfigurationViewModel();

        public ConfigurationView()
        {
            DataContext = ViewModel;
            InitializeComponent();
        }

        public ConfigurationView(ConfigurationViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}
