using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ResumesTheSpecifiedJobResponse
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
}