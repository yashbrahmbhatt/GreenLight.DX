using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheRobotLogsResponse
    {
        [JsonProperty("value")]
        public List<Value39> Value { get; set; }
    }

    public class Value39
    {
        [JsonProperty("Level")]
        public string Level { get; set; }

        [JsonProperty("WindowsIdentity")]
        public string WindowsIdentity { get; set; }

        [JsonProperty("ProcessName")]
        public string ProcessName { get; set; }

        [JsonProperty("TimeStamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("JobKey")]
        public string JobKey { get; set; }

        [JsonProperty("RawMessage")]
        public string RawMessage { get; set; }

        [JsonProperty("RobotName")]
        public string RobotName { get; set; }

        [JsonProperty("HostMachineName")]
        public string HostMachineName { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineKey")]
        public string MachineKey { get; set; }

        [JsonProperty("RuntimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}