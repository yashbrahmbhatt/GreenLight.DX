using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesAProcessAlertRequest
    {
        [JsonProperty("processAlert")]
        public ProcessAlert ProcessAlert { get; set; }
    }

    public class ProcessAlert
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ProcessName")]
        public string ProcessName { get; set; }

        [JsonProperty("RobotName")]
        public string RobotName { get; set; }

        [JsonProperty("Severity")]
        public string Severity { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}