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
    /// Interaction logic for AssetsRowControl.xaml
    /// </summary>
    public partial class AssetsRowControl : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(nameof(Model), typeof(AssetRowViewModel), typeof(AssetsRowControl),
    new PropertyMetadata()
    {
        PropertyChangedCallback = (d, e) =>
        {
            if (d is AssetsRowControl control)
            {
                control.Model = (AssetRowViewModel)e.NewValue;
                control.DataContext = (AssetRowViewModel)e.NewValue;
            }
        }
    });
        public AssetRowViewModel Model
        {
            get => (AssetRowViewModel)GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }

        public AssetsRowControl(AssetRowViewModel model)
        {
            InitializeComponent();
        }
        public AssetsRowControl() : this(new AssetRowViewModel()) { }
    }
}
