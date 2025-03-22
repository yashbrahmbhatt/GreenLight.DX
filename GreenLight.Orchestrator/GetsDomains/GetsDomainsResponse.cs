using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsDomainsResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isDefault")]
        public string IsDefault { get; set; }
    }
}