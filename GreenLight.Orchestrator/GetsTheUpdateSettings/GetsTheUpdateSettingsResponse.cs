using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheUpdateSettingsResponse
    {
        [JsonProperty("UpdateServerSource")]
        public string UpdateServerSource { get; set; }

        [JsonProperty("UpdateServerUrl")]
        public string UpdateServerUrl { get; set; }

        [JsonProperty("PollingInterval")]
        public string PollingInterval { get; set; }
    }
}