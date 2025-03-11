using GreenLight.DX.Config.Studio.Test.Mocks;
using GreenLight.DX.Config.Studio.ViewModels;
using GreenLight.DX.Config.Studio.Windows;
using GreenLight.DX.Shared.Hermes.Services;
using GreenLight.DX.Shared.Hermes.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Prism.Events;
using System;
using System.Configuration;
using System.Windows;
using UiPath.Activities.Api.Base;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Activities;
using UiPath.Studio.Activities.Api.Analyzer;
using UiPath.Studio.Activities.Api.BusyService;
using UiPath.Studio.Activities.Api.DialogServices;
using UiPath.Studio.Activities.Api.DocumentFactory;
using UiPath.Studio.Activities.Api.ExpressionEditor;
using UiPath.Studio.Activities.Api.Expressions;
using UiPath.Studio.Activities.Api.FileService;
using UiPath.Studio.Activities.Api.Forms;
using UiPath.Studio.Activities.Api.Licensing;
using UiPath.Studio.Activities.Api.Locations;
using UiPath.Studio.Activities.Api.Mocking;
using UiPath.Studio.Activities.Api.ObjectLibrary;
using UiPath.Studio.Activities.Api.OnlineServices;
using UiPath.Studio.Activities.Api.PackageBindings;
using UiPath.Studio.Activities.Api.Policies;
using UiPath.Studio.Activities.Api.ProjectProperties;
using UiPath.Studio.Activities.Api.SapIntegration;
using UiPath.Studio.Activities.Api.ScopedActivities;
using UiPath.Studio.Activities.Api.Settings;
using UiPath.Studio.Activities.Api.UiConnection;
using UiPath.Studio.Activities.Api.Widgets;
using UiPath.Studio.Activities.Api.Wizards;
using UiPath.Studio.Activities.Api.Workflow;
using UiPath.Studio.Api.Telemetry;
using UiPath.Studio.Api.Theme;

namespace GreenLight.DX.Config.Studio.Test
{
    //public static class Program
    //{
    //    [STAThread] // Ensure STA mode for WPF
    //    public static void Main(string[] args)
    //    {

    //        var app = new Application();
    //        var hermes = new HermesService(app.Dispatcher);
    //        var services = new ServiceCollection()
    //            .AddSingleton<IEventAggregator>(new EventAggregator())
    //            .AddSingleton<IWorkflowDesignApi>(new MockWorkflowDesignApi())
    //            .AddSingleton<IHermesService>(hermes)
    //            .BuildServiceProvider();



    //        var window = new MainWindow(services, new MainWindowViewModel(services, new Models.ProjectModel()));
    //        //var window = new ConfigurationWindow();

    //        app.Run(window); // Starts the WPF message loop
    //    }

    //}

    
}
