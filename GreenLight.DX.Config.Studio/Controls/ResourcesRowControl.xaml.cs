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
    /// Interaction logic for ResourcesRowControl.xaml
    /// </summary>
    public partial class ResourcesRowControl : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(nameof(Model), typeof(ResourceRowViewModel), typeof(ResourcesRowControl),
            new PropertyMetadata()
            {
                PropertyChangedCallback = (d, e) =>
                {
                    if (d is ResourcesRowControl control)
                    {
                        control.DataContext = e.NewValue;
                    }
                }
            });
        public ResourceRowViewModel Model
        {
            get => (ResourceRowViewModel)GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }


        public ResourcesRowControl() {
            InitializeComponent();
        }
    }
}
