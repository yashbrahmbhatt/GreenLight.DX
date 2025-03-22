using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class PartiallyUpdatesAReleaseRequest
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
        public List<CurrentVersion2> ReleaseVersions { get; set; }

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
}