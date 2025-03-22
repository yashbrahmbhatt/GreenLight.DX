using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewTaskDefinitionRequest
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Properties")]
        public Properties2 Properties { get; set; }
    }

    public class Properties2
    {
        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("allowedActions")]
        public List<string> AllowedActions { get; set; }
    }
}