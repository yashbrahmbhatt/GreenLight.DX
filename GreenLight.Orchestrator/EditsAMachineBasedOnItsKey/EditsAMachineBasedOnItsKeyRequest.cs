using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EditsAMachineBasedOnItsKeyRequest
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
}