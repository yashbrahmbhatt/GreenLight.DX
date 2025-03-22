using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsTheMachinesAssignedToAFolderResponse
    {
        [JsonProperty("value")]
        public List<Value13> Value { get; set; }
    }

    public class Value13
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsAssignedToFolder")]
        public bool IsAssignedToFolder { get; set; }

        [JsonProperty("HasMachineRobots")]
        public bool HasMachineRobots { get; set; }

        [JsonProperty("IsInherited")]
        public bool IsInherited { get; set; }

        [JsonProperty("PropagateToSubFolders")]
        public bool PropagateToSubFolders { get; set; }

        [JsonProperty("InheritedFromFolderName")]
        public string InheritedFromFolderName { get; set; }

        [JsonProperty("UpdateInfo")]
        public UpdateInfo UpdateInfo { get; set; }

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

    public class MaintenanceWindow
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("jobStopStrategy")]
        public string JobStopStrategy { get; set; }

        [JsonProperty("cronExpression")]
        public string CronExpression { get; set; }

        [JsonProperty("timezoneId")]
        public string TimezoneId { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("nextExecutionTime")]
        public string NextExecutionTime { get; set; }
    }

    public class RobotUsers
    {
        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("HasTriggers")]
        public string HasTriggers { get; set; }
    }

    public class RobotVersions
    {
        [JsonProperty("Count")]
        public string Count { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }
    }

    public class UpdatePolicy
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("SpecificVersion")]
        public string SpecificVersion { get; set; }
    }

    public class VpnSettings
    {
        [JsonProperty("cidr")]
        public string Cidr { get; set; }
    }

    public class UpdateInfo
    {
    }
}