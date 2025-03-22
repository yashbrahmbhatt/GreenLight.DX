using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsOrchestratorSettingsUsedByActivitiesResponse
    {
        [JsonProperty("ApiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("SignalR")]
        public SignalR SignalR { get; set; }
    }

    public class SignalR
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("skipNegotiation")]
        public string SkipNegotiation { get; set; }
    }
}