using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CancelsOrTerminatesTheSpecifiedJobsRequest
    {
        [JsonProperty("jobIds")]
        public List<string> JobIds { get; set; }

        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}