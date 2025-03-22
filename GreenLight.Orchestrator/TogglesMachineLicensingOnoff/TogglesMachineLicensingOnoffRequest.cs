using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TogglesMachineLicensingOnoffRequest
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("robotType")]
        public string RobotType { get; set; }
    }
}