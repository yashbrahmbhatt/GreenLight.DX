using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsJobsResponse
    {
        [JsonProperty("value")]
        public List<Value16> Value { get; set; }
    }

    public class Value16
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("JobPriority")]
        public string JobPriority { get; set; }

        [JsonProperty("SpecificPriorityValue")]
        public string SpecificPriorityValue { get; set; }

        [JsonProperty("Robot")]
        public Robots Robot { get; set; }

        [JsonProperty("Release")]
        public Release Release { get; set; }

        [JsonProperty("ResourceOverwrites")]
        public string ResourceOverwrites { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("SourceType")]
        public string SourceType { get; set; }

        [JsonProperty("BatchExecutionKey")]
        public string BatchExecutionKey { get; set; }

        [JsonProperty("Info")]
        public string Info { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("StartingScheduleId")]
        public string StartingScheduleId { get; set; }

        [JsonProperty("ReleaseName")]
        public string ReleaseName { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("InputArguments")]
        public string InputArguments { get; set; }

        [JsonProperty("EnvironmentVariables")]
        public string EnvironmentVariables { get; set; }

        [JsonProperty("OutputArguments")]
        public string OutputArguments { get; set; }

        [JsonProperty("HostMachineName")]
        public string HostMachineName { get; set; }

        [JsonProperty("HasMediaRecorded")]
        public string HasMediaRecorded { get; set; }

        [JsonProperty("HasVideoRecorded")]
        public string HasVideoRecorded { get; set; }

        [JsonProperty("PersistenceId")]
        public string PersistenceId { get; set; }

        [JsonProperty("ResumeVersion")]
        public string ResumeVersion { get; set; }

        [JsonProperty("StopStrategy")]
        public string StopStrategy { get; set; }

        [JsonProperty("RuntimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("RequiresUserInteraction")]
        public string RequiresUserInteraction { get; set; }

        [JsonProperty("ReleaseVersionId")]
        public string ReleaseVersionId { get; set; }

        [JsonProperty("EntryPointPath")]
        public string EntryPointPath { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("OrganizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("ProcessType")]
        public string ProcessType { get; set; }

        [JsonProperty("Machine")]
        public Machine Machine { get; set; }

        [JsonProperty("ProfilingOptions")]
        public string ProfilingOptions { get; set; }

        [JsonProperty("ResumeOnSameContext")]
        public string ResumeOnSameContext { get; set; }

        [JsonProperty("LocalSystemAccount")]
        public string LocalSystemAccount { get; set; }

        [JsonProperty("OrchestratorUserIdentity")]
        public string OrchestratorUserIdentity { get; set; }

        [JsonProperty("RemoteControlAccess")]
        public string RemoteControlAccess { get; set; }

        [JsonProperty("StartingTriggerId")]
        public string StartingTriggerId { get; set; }

        [JsonProperty("MaxExpectedRunningTimeSeconds")]
        public string MaxExpectedRunningTimeSeconds { get; set; }

        [JsonProperty("ServerlessJobType")]
        public string ServerlessJobType { get; set; }

        [JsonProperty("ParentJobKey")]
        public string ParentJobKey { get; set; }

        [JsonProperty("ResumeTime")]
        public string ResumeTime { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("JobError")]
        public JobError JobError { get; set; }

        [JsonProperty("ErrorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("FpsProperties")]
        public string FpsProperties { get; set; }

        [JsonProperty("TraceId")]
        public string TraceId { get; set; }

        [JsonProperty("ParentSpanId")]
        public string ParentSpanId { get; set; }

        [JsonProperty("AutopilotForRobots")]
        public AutopilotForRobots AutopilotForRobots { get; set; }

        [JsonProperty("FpsContext")]
        public string FpsContext { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Release
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ProcessKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("ProcessVersion")]
        public string ProcessVersion { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("IsLatestVersion")]
        public string IsLatestVersion { get; set; }

        [JsonProperty("IsProcessDeleted")]
        public string IsProcessDeleted { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("EnvironmentId")]
        public string EnvironmentId { get; set; }

        [JsonProperty("EnvironmentName")]
        public string EnvironmentName { get; set; }

        [JsonProperty("Environment")]
        public GetsASingleEnvironmentResponse Environment { get; set; }

        [JsonProperty("EntryPointId")]
        public string EntryPointId { get; set; }

        [JsonProperty("EntryPointPath")]
        public string EntryPointPath { get; set; }

        [JsonProperty("EntryPoint")]
        public EntryPoint EntryPoint { get; set; }

        [JsonProperty("InputArguments")]
        public string InputArguments { get; set; }

        [JsonProperty("EnvironmentVariables")]
        public string EnvironmentVariables { get; set; }

        [JsonProperty("ProcessType")]
        public string ProcessType { get; set; }

        [JsonProperty("SupportsMultipleEntryPoints")]
        public string SupportsMultipleEntryPoints { get; set; }

        [JsonProperty("RequiresUserInteraction")]
        public string RequiresUserInteraction { get; set; }

        [JsonProperty("MinRequiredRobotVersion")]
        public string MinRequiredRobotVersion { get; set; }

        [JsonProperty("IsAttended")]
        public string IsAttended { get; set; }

        [JsonProperty("IsCompiled")]
        public string IsCompiled { get; set; }

        [JsonProperty("AutomationHubIdeaUrl")]
        public string AutomationHubIdeaUrl { get; set; }

        [JsonProperty("CurrentVersion")]
        public CurrentVersion2 CurrentVersion { get; set; }

        [JsonProperty("ReleaseVersions")]
        public List<CurrentVersion> ReleaseVersions { get; set; }

        [JsonProperty("Arguments")]
        public Arguments Arguments { get; set; }

        [JsonProperty("ProcessSettings")]
        public ProcessSettings ProcessSettings { get; set; }

        [JsonProperty("VideoRecordingSettings")]
        public VideoRecordingSettings VideoRecordingSettings { get; set; }

        [JsonProperty("AutoUpdate")]
        public string AutoUpdate { get; set; }

        [JsonProperty("HiddenForAttendedUser")]
        public string HiddenForAttendedUser { get; set; }

        [JsonProperty("FeedId")]
        public string FeedId { get; set; }

        [JsonProperty("JobPriority")]
        public string JobPriority { get; set; }

        [JsonProperty("SpecificPriorityValue")]
        public string SpecificPriorityValue { get; set; }

        [JsonProperty("FolderKey")]
        public string FolderKey { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("OrganizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonProperty("TargetFramework")]
        public string TargetFramework { get; set; }

        [JsonProperty("RobotSize")]
        public string RobotSize { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("RemoteControlAccess")]
        public string RemoteControlAccess { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Machine
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LicenseKey")]
        public string LicenseKey { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Scope")]
        public string Scope { get; set; }

        [JsonProperty("NonProductionSlots")]
        public string NonProductionSlots { get; set; }

        [JsonProperty("UnattendedSlots")]
        public string UnattendedSlots { get; set; }

        [JsonProperty("HeadlessSlots")]
        public string HeadlessSlots { get; set; }

        [JsonProperty("TestAutomationSlots")]
        public string TestAutomationSlots { get; set; }

        [JsonProperty("HostingSlots")]
        public string HostingSlots { get; set; }

        [JsonProperty("AppTestSlots")]
        public string AppTestSlots { get; set; }

        [JsonProperty("AutomationCloudSlots")]
        public string AutomationCloudSlots { get; set; }

        [JsonProperty("AutomationCloudTestAutomationSlots")]
        public string AutomationCloudTestAutomationSlots { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("EndpointDetectionStatus")]
        public string EndpointDetectionStatus { get; set; }

        [JsonProperty("RobotVersions")]
        public List<RobotVersions> RobotVersions { get; set; }

        [JsonProperty("RobotUsers")]
        public List<RobotUsers> RobotUsers { get; set; }

        [JsonProperty("AutomationType")]
        public string AutomationType { get; set; }

        [JsonProperty("TargetFramework")]
        public string TargetFramework { get; set; }

        [JsonProperty("ServerlessLicensingModel")]
        public string ServerlessLicensingModel { get; set; }

        [JsonProperty("UpdatePolicy")]
        public UpdatePolicy UpdatePolicy { get; set; }

        [JsonProperty("ClientSecret")]
        public string ClientSecret { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("MaintenanceWindow")]
        public MaintenanceWindow MaintenanceWindow { get; set; }

        [JsonProperty("VpnSettings")]
        public VpnSettings VpnSettings { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class ProcessSettings
    {
        [JsonProperty("ErrorRecordingEnabled")]
        public string ErrorRecordingEnabled { get; set; }

        [JsonProperty("Duration")]
        public string Duration { get; set; }

        [JsonProperty("Frequency")]
        public string Frequency { get; set; }

        [JsonProperty("Quality")]
        public string Quality { get; set; }

        [JsonProperty("AutoStartProcess")]
        public string AutoStartProcess { get; set; }

        [JsonProperty("AlwaysRunning")]
        public string AlwaysRunning { get; set; }

        [JsonProperty("AutopilotForRobots")]
        public AutopilotForRobots AutopilotForRobots { get; set; }
    }

    public class EntryPoint
    {
        [JsonProperty("UniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("InputArguments")]
        public string InputArguments { get; set; }

        [JsonProperty("OutputArguments")]
        public string OutputArguments { get; set; }

        [JsonProperty("DataVariation")]
        public DataVariation DataVariation { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class CurrentVersion2
    {
        [JsonProperty("ReleaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("VersionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("ReleaseName")]
        public string ReleaseName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class JobError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class DataVariation
    {
        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("ContentType")]
        public string ContentType { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class VideoRecordingSettings
    {
        [JsonProperty("VideoRecordingType")]
        public string VideoRecordingType { get; set; }

        [JsonProperty("QueueItemVideoRecordingType")]
        public string QueueItemVideoRecordingType { get; set; }

        [JsonProperty("MaxDurationSeconds")]
        public string MaxDurationSeconds { get; set; }
    }

    public class Arguments
    {
        [JsonProperty("Input")]
        public string Input { get; set; }

        [JsonProperty("Output")]
        public string Output { get; set; }
    }

    public class AutopilotForRobots
    {
        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("HealingEnabled")]
        public string HealingEnabled { get; set; }
    }

    public class CommodoB2
    {
    }

    public class Consequata86
    {
    }

    public class Dolore1
    {
    }

    public class Dolore3
    {
    }

    public class Esse9d2
    {
    }

    public class Lorem41
    {
    }

    public class Minim4
    {
    }

    public class Sintc76
    {
    }

    public class Sunt00d
    {
    }
}