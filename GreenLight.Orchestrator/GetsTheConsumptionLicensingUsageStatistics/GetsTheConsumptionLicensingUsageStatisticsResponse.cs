using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheConsumptionLicensingUsageStatisticsResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("used")]
        public string Used { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}