using GreenLight.DX.Config.Studio.Models;
using GreenLight.DX.Config.Studio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SettingsRowControl.xaml
    /// </summary>
    public partial class SettingsRowControl : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(nameof(Model), typeof(SettingRowViewModel), typeof(SettingsRowControl),
            new PropertyMetadata()
            {
                PropertyChangedCallback = (d, e) =>
                {
                    if (d is SettingsRowControl control)
                    {
                        control.Model = (SettingRowViewModel)e.NewValue;
                        control.DataContext = control.Model;
                    }
                }
            });
        public SettingRowViewModel Model
        {
            get => (SettingRowViewModel)GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }

        public SettingsRowControl() {
            InitializeComponent();
        }
    }
}
