using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class PostNewEnvironmentResponse
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Robots")]
        public List<Robots> Robots { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}