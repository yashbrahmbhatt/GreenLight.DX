using GreenLight.DX.Windows;
using System;
using System.Windows;

namespace GreenLight.DevEx.Config.Test
{
    public static class Program
    {
        [STAThread] // Ensure STA mode for WPF
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var app = new Application();
            var window = new MainWindow();
            //var window = new ConfigurationWindow();

            app.Run(window); // Starts the WPF message loop
        }
    }
}
