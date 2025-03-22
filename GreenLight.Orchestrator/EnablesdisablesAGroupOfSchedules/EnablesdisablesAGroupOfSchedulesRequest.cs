using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EnablesdisablesAGroupOfSchedulesRequest
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("multistatusEnabled")]
        public string MultistatusEnabled { get; set; }

        [JsonProperty("scheduleIds")]
        public List<string> ScheduleIds { get; set; }
    }
}