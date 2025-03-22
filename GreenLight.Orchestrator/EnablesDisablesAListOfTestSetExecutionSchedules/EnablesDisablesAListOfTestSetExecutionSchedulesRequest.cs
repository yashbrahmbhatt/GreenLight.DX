using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EnablesDisablesAListOfTestSetExecutionSchedulesRequest
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("testSetScheduleIds")]
        public List<string> TestSetScheduleIds { get; set; }
    }
}