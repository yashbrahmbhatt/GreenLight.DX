using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetsTheExecutionCapabilitiesForASpecifiedHostRequest
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("maintenanceMode")]
        public string MaintenanceMode { get; set; }

        [JsonProperty("stopJobsStrategy")]
        public string StopJobsStrategy { get; set; }
    }
}