using GreenLight.DX.Shared.Hermes;
using GreenLight.DX.Shared.Hermes.Models;
using GreenLight.DX.Shared.Hermes.Services;
using GreenLight.DX.Shared.Hermes.ViewModels;
using GreenLight.DX.Shared.Hermes.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace GreenLight.DX.Shared.Hermes.Test
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var context = "Unit Test";
            var app = new Application();
            var container = new ServiceCollection()
                .AddSingleton<IHermesService>(new HermesService(app.Dispatcher))
                .BuildServiceProvider();

            var logService = container.GetRequiredService<IHermesService>();
            logService.Info(context, "This is an info message.");
            logService.Warning(context, "This is a warning message.");
            logService.Error(context, "This is an error message.");
            logService.Debug(context, "This is a debug message.");
            logService.Info(context + "_Different", "This is a different context message.");
            logService.ShowHermesWindow();
            app.Run();
        }
    }
}
