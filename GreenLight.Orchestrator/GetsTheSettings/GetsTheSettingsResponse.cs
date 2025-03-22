using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheSettingsResponse
    {
        [JsonProperty("value")]
        public List<Value46> Value { get; set; }
    }

    public class Value46
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Scope")]
        public string Scope { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}