using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsMachineRuntimeSessionsResponse
    {
        [JsonProperty("value")]
        public List<Value44> Value { get; set; }
    }

    public class Value44
    {
        [JsonProperty("SessionId")]
        public string SessionId { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("MaintenanceMode")]
        public string MaintenanceMode { get; set; }

        [JsonProperty("HostMachineName")]
        public string HostMachineName { get; set; }

        [JsonProperty("RuntimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("MachineType")]
        public string MachineType { get; set; }

        [JsonProperty("MachineScope")]
        public string MachineScope { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("IsUnresponsive")]
        public string IsUnresponsive { get; set; }

        [JsonProperty("Runtimes")]
        public string Runtimes { get; set; }

        [JsonProperty("UsedRuntimes")]
        public string UsedRuntimes { get; set; }

        [JsonProperty("ServiceUserName")]
        public string ServiceUserName { get; set; }

        [JsonProperty("ReportingTime")]
        public string ReportingTime { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("DebugModeExpirationDate")]
        public string DebugModeExpirationDate { get; set; }

        [JsonProperty("Platform")]
        public string Platform { get; set; }

        [JsonProperty("EndpointDetection")]
        public string EndpointDetection { get; set; }

        [JsonProperty("TriggersCount")]
        public string TriggersCount { get; set; }
    }
}