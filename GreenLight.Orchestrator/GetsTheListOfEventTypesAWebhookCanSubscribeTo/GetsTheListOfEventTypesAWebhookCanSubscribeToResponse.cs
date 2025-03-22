using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheListOfEventTypesAWebhookCanSubscribeToResponse
    {
        [JsonProperty("value")]
        public List<Value61> Value { get; set; }
    }

    public class Value61
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Group")]
        public string Group { get; set; }
    }
}