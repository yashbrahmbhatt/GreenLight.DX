using GreenLight.DX.Config.Studio.Windows;
using System;
using System.Windows;

namespace GreenLight.DX.Config.Studio.Test
{
    public static class Program
    {
        [STAThread] // Ensure STA mode for WPF
        public static void Main(string[] args)
        {

            var app = new Application();
            var window = new MainWindow();
            //var window = new ConfigurationWindow();

            app.Run(window); // Starts the WPF message loop
        }
    }
}
