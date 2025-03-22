using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheLicensingUsageStatisticsResponse
    {
        [JsonProperty("robotType")]
        public string RobotType { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}