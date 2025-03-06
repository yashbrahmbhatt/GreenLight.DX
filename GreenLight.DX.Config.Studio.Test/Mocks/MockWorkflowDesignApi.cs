using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Activities.Api.Base;
using UiPath.Studio.Activities.Api.Activities;
using UiPath.Studio.Activities.Api.Analyzer;
using UiPath.Studio.Activities.Api.BusyService;
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
using UiPath.Studio.Activities.Api.Widgets;
using UiPath.Studio.Activities.Api.Wizards;
using UiPath.Studio.Activities.Api.Workflow;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Api.Telemetry;
using UiPath.Studio.Api.Theme;
using Moq;
using UiPath.Studio.Activities.Api.DialogServices;
using UiPath.Studio.Activities.Api.UiConnection;
using System.IO;

namespace GreenLight.DX.Config.Studio.Test.Mocks
{
    public class MockWorkflowDesignApi : IWorkflowDesignApi
    {
        public Mock<IOrganizationalSettingsService> MockOrganizationalSettingsService { get; } = new Mock<IOrganizationalSettingsService>();
        public IOrganizationalSettingsService OrganizationalSettings => MockOrganizationalSettingsService.Object;

        public Mock<IActivitiesSettingsService> MockActivitiesSettingsService { get; } = new Mock<IActivitiesSettingsService>();
        public IActivitiesSettingsService Settings => MockActivitiesSettingsService.Object;

        public Mock<ITelemetryService> MockTelemetryService { get; } = new Mock<ITelemetryService>();
        public ITelemetryService Telemetry => MockTelemetryService.Object;

        public Mock<IThemeService> MockThemeService { get; } = new Mock<IThemeService>();
        public IThemeService Theme => MockThemeService.Object;

        public Mock<IWizardsService> MockWizardsService { get; } = new Mock<IWizardsService>();
        public IWizardsService Wizards => MockWizardsService.Object;

        public Mock<IAccessProvider> MockAccessProvider { get; } = new Mock<IAccessProvider>();
        public IAccessProvider AccessProvider => MockAccessProvider.Object;

        public Mock<IAnalyzerConfigurationService> MockWorkflowAnalyzerConfigService { get; } = new Mock<IAnalyzerConfigurationService>();
        public IAnalyzerConfigurationService WorkflowAnalyzerConfigService => MockWorkflowAnalyzerConfigService.Object;

        public Mock<IProjectPropertiesService> MockProjectPropertiesService { get; } = new Mock<IProjectPropertiesService>();
        public IProjectPropertiesService ProjectPropertiesService => MockProjectPropertiesService.Object;

        public Mock<IScopedActivitiesService> MockScopedActivitiesService { get; } = new Mock<IScopedActivitiesService>();
        public IScopedActivitiesService ScopedActivitiesService => MockScopedActivitiesService.Object;

        public Mock<IActivitySynonymService> MockActivitySynonymService { get; } = new Mock<IActivitySynonymService>();
        public IActivitySynonymService ActivitySynonymService => MockActivitySynonymService.Object;

        public Mock<IAttendedActivityService> MockAttendedActivityService { get; } = new Mock<IAttendedActivityService>();
        public IAttendedActivityService AttendedActivityService => MockAttendedActivityService.Object;

        public Mock<IDesignTimeExpressionExpanderService> MockDesignTimeExpressionExpanderService { get; } = new Mock<IDesignTimeExpressionExpanderService>();
        public IDesignTimeExpressionExpanderService DesignTimeExpressionExpanderService => MockDesignTimeExpressionExpanderService.Object;

        public Mock<IActivityFactoryRepository> MockActivityFactory { get; } = new Mock<IActivityFactoryRepository>();
        public IActivityFactoryRepository ActivityFactory => MockActivityFactory.Object;

        public Mock<ILibraryService> MockObjectLibrary { get; } = new Mock<ILibraryService>();
        public ILibraryService ObjectLibrary => MockObjectLibrary.Object;

        public Mock<IExtensionsInstallerService> MockExtensionsInstallerService { get; } = new Mock<IExtensionsInstallerService>();
        public IExtensionsInstallerService ExtensionsInstallerService => MockExtensionsInstallerService.Object;

        public Mock<IStudioDesignSettingsService> MockStudioDesignSettings { get; } = new Mock<IStudioDesignSettingsService>();
        public IStudioDesignSettingsService StudioDesignSettings => MockStudioDesignSettings.Object;

        public Mock<IExpressionService> MockExpressionService { get; } = new Mock<IExpressionService>();
        public IExpressionService ExpressionService => MockExpressionService.Object;

        public Mock<IExclusiveScopedActivitiesService> MockExclusiveScopedActivitiesService { get; } = new Mock<IExclusiveScopedActivitiesService>();
        public IExclusiveScopedActivitiesService ExclusiveScopedActivitiesService => MockExclusiveScopedActivitiesService.Object;

        public Mock<IMockActivityService> MockMockActivityService { get; } = new Mock<IMockActivityService>();
        public IMockActivityService MockActivityService => MockMockActivityService.Object;

        public Mock<IWindowOperationsService> MockWindowOperations { get; } = new Mock<IWindowOperationsService>();
        public IWindowOperationsService WindowOperations => MockWindowOperations.Object;

        public Mock<IWorkflowOperationsService> MockWorkflowOperationsService { get; } = new Mock<IWorkflowOperationsService>();
        public IWorkflowOperationsService WorkflowOperationsService => MockWorkflowOperationsService.Object;

        public Mock<IPackageBindingsService> MockPackageBindings { get; } = new Mock<IPackageBindingsService>();
        public IPackageBindingsService PackageBindings => MockPackageBindings.Object;

        public Mock<IOrchestratorApiService> MockOrchestratorApiService { get; } = new Mock<IOrchestratorApiService>();
        public IOrchestratorApiService OrchestratorApiService => MockOrchestratorApiService.Object;

        public Mock<ILicenseApiService> MockLicenseApiService { get; } = new Mock<ILicenseApiService>();
        public ILicenseApiService LicenseApiService => MockLicenseApiService.Object;

        public Mock<IStudioBusyService> MockBusyService { get; } = new Mock<IStudioBusyService>();
        public IStudioBusyService BusyService => MockBusyService.Object;

        public Mock<IActivityTriggerService> MockActivityTriggerService { get; } = new Mock<IActivityTriggerService>();
        public IActivityTriggerService ActivityTriggerService => MockActivityTriggerService.Object;

        public Mock<ILocalTriggersService> MockLocalTriggersService { get; } = new Mock<ILocalTriggersService>();
        public ILocalTriggersService LocalTriggersService => MockLocalTriggersService.Object;

        public Mock<IScreenshotStorageService> MockScreenshotStorageService { get; } = new Mock<IScreenshotStorageService>();
        public IScreenshotStorageService ScreenshotStorageService => MockScreenshotStorageService.Object;

        public Mock<IVariableService> MockVariableService { get; } = new Mock<IVariableService>();
        public IVariableService VariableService => MockVariableService.Object;

        public Mock<IArgumentService> MockArgumentService { get; } = new Mock<IArgumentService>();
        public IArgumentService ArgumentService => MockArgumentService.Object;

        public Mock<IOrchestratorFolderService> MockOrchestratorFolderService { get; } = new Mock<IOrchestratorFolderService>();
        public IOrchestratorFolderService OrchestratorFolderService => MockOrchestratorFolderService.Object;

        public Mock<IDialogService> MockDialogService { get; } = new Mock<IDialogService>();
        public IDialogService DialogService => MockDialogService.Object;

        public Mock<IUIConnectionService> MockUIConnectionService { get; } = new Mock<IUIConnectionService>();
        public IUIConnectionService UIConnectionService => MockUIConnectionService.Object;

        public Mock<IExpressionEditorServiceFactory> MockExpressionEditorServiceFactory { get; } = new Mock<IExpressionEditorServiceFactory>();
        public IExpressionEditorServiceFactory ExpressionEditorServiceFactory => MockExpressionEditorServiceFactory.Object;

        public Mock<IDesignFormsService> MockFormsService { get; } = new Mock<IDesignFormsService>();
        public IDesignFormsService FormsService => MockFormsService.Object;

        public Mock<IDotnetRuntime> MockDotnetRuntime { get; } = new Mock<IDotnetRuntime>();
        public IDotnetRuntime DotnetRuntime => MockDotnetRuntime.Object;

        public Mock<IWidgetSupportInfoService> MockWidgetSupportInfoService { get; } = new Mock<IWidgetSupportInfoService>();
        public IWidgetSupportInfoService WidgetSupportInfoService => MockWidgetSupportInfoService.Object;

        public Mock<ISapIntegrationService> MockSapIntegrationService { get; } = new Mock<ISapIntegrationService>();
        public ISapIntegrationService SapIntegrationService => MockSapIntegrationService.Object;

        public Mock<IOnlineServicesConfiguration> MockOnlineServicesConfiguration { get; } = new Mock<IOnlineServicesConfiguration>();
        public IOnlineServicesConfiguration OnlineServicesConfiguration => MockOnlineServicesConfiguration.Object;

        public Mock<IDocumentFactoryService> MockDocumentFactoryService { get; } = new Mock<IDocumentFactoryService>();
        public IDocumentFactoryService DocumentFactoryService => MockDocumentFactoryService.Object;

        public Mock<IPoliciesService> MockPoliciesService { get; } = new Mock<IPoliciesService>();
        public IPoliciesService PoliciesService => MockPoliciesService.Object;

        public Mock<IApiToolboxService> MockToolboxService { get; } = new Mock<IApiToolboxService>();
        public IApiToolboxService ToolboxService => MockToolboxService.Object;

        IDialogService IWorkflowDesignApi.DialogService => throw new NotImplementedException();

        IUIConnectionService IWorkflowDesignApi.UIConnectionService => throw new NotImplementedException();

        public MockWorkflowDesignApi()
        {
            MockProjectPropertiesService.Setup(x => x.GetProjectDirectory()).Returns($"C:\\Users\\eyash\\Downloads");
            MockBusyService.Setup(x => x.Begin(It.Is<string>(s => true))).Returns(async () => new Mock<IStudioBusyScope>().Object);
        }

        public bool HasFeature(string name)
        {
            throw new NotImplementedException();
        }
    }
}
