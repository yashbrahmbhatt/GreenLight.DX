using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsNamedUserLicensesResponse
    {
        [JsonProperty("value")]
        public List<Value21> Value { get; set; }
    }

    public class Value21
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("LastLoginDate")]
        public string LastLoginDate { get; set; }

        [JsonProperty("MachinesCount")]
        public string MachinesCount { get; set; }

        [JsonProperty("IsLicensed")]
        public string IsLicensed { get; set; }

        [JsonProperty("IsExternalLicensed")]
        public string IsExternalLicensed { get; set; }

        [JsonProperty("ActiveRobotId")]
        public string ActiveRobotId { get; set; }

        [JsonProperty("MachineNames")]
        public List<string> MachineNames { get; set; }

        [JsonProperty("ActiveMachineNames")]
        public List<string> ActiveMachineNames { get; set; }
    }
}