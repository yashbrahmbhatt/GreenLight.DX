using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheAuthenticationSettingsResponse
    {
        [JsonProperty("Keys")]
        public List<string> Keys { get; set; }

        [JsonProperty("Values")]
        public List<string> Values { get; set; }
    }
}