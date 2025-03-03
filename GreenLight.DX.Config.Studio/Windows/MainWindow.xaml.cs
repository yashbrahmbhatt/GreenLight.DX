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
using System.Windows.Shapes;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Studio.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProjectViewModel ViewModel { get; set; } 


        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ProjectViewModel
            {
                CloseWindowAction = Close
            };
            DataContext = ViewModel;
        }

        public MainWindow(ProjectViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.CloseWindowAction = Close;
            DataContext = ViewModel;
        }

        public MainWindow(ProjectViewModel viewModel, IWorkflowDesignApi workflowDesignApi)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.WorkflowDesignApi = workflowDesignApi;
            ViewModel.CloseWindowAction = Close;
            DataContext = ViewModel;
        }
    }
}
