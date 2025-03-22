using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheHostAdminLogsResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("maintenanceLogs")]
        public List<MaintenanceLogs> MaintenanceLogs { get; set; }

        [JsonProperty("jobStopsAttempted")]
        public string JobStopsAttempted { get; set; }

        [JsonProperty("jobKillsAttempted")]
        public string JobKillsAttempted { get; set; }

        [JsonProperty("triggersSkipped")]
        public string TriggersSkipped { get; set; }

        [JsonProperty("systemTriggersSkipped")]
        public string SystemTriggersSkipped { get; set; }
    }

    public class MaintenanceLogs
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }
    }
}