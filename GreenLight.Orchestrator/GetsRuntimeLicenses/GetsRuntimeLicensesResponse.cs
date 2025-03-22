using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsRuntimeLicensesResponse
    {
        [JsonProperty("value")]
        public List<Value22> Value { get; set; }
    }

    public class Value22
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("HostMachineName")]
        public string HostMachineName { get; set; }

        [JsonProperty("ServiceUserName")]
        public string ServiceUserName { get; set; }

        [JsonProperty("MachineType")]
        public string MachineType { get; set; }

        [JsonProperty("Runtimes")]
        public string Runtimes { get; set; }

        [JsonProperty("RobotsCount")]
        public string RobotsCount { get; set; }

        [JsonProperty("ExecutingCount")]
        public string ExecutingCount { get; set; }

        [JsonProperty("IsOnline")]
        public string IsOnline { get; set; }

        [JsonProperty("IsLicensed")]
        public string IsLicensed { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("MachineScope")]
        public string MachineScope { get; set; }
    }
}