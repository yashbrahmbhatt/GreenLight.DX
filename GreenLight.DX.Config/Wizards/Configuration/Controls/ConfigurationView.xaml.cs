using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace GreenLight.DX.Config.Wizards.Configuration.Controls
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>

    public partial class ConfigurationView : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(nameof(Model), typeof(ConfigurationViewModel), typeof(ConfigurationView),
            new PropertyMetadata()
            {
                PropertyChangedCallback = (d, e) =>
                {
                    if (d is ConfigurationView control)
                    {
                        control.Model = (ConfigurationViewModel)e.NewValue;
                        control.DataContext = control.Model;
                    }
                    else
                    {
                        throw new Exception("Invalid DataContext");
                    }
                }
            });
        public ConfigurationViewModel Model
        {
            get => (ConfigurationViewModel)GetValue(ModelProperty);
            set
            {
                SetValue(ModelProperty, value);
            }
        }

        public ConfigurationView()
        {
            InitializeComponent();
        }
    }
}
