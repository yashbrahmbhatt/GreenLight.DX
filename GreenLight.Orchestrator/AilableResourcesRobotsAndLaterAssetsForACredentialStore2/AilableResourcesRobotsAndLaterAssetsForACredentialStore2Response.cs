using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AilableResourcesRobotsAndLaterAssetsForACredentialStore2Response
    {
        [JsonProperty("value")]
        public List<Value9> Value { get; set; }
    }

    public class Value9
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}