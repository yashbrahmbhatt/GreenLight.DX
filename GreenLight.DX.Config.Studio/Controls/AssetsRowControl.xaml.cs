﻿using GreenLight.DX.Config.Studio.ViewModels;
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
                control.DataContext = e.NewValue;
            }
        }
    });
        public AssetRowViewModel Model { get; set; }

        public AssetsRowControl(AssetRowViewModel model)
        {
            InitializeComponent();
            Model = model;
            DataContext = Model;
        }
        public AssetsRowControl() : this(new AssetRowViewModel()) { }
    }
}
