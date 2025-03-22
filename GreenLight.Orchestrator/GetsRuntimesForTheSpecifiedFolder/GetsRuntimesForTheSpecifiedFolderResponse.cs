using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsRuntimesForTheSpecifiedFolderResponse
    {
        [JsonProperty("value")]
        public List<Value24> Value { get; set; }
    }

    public class Value24
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Total")]
        public string Total { get; set; }

        [JsonProperty("Connected")]
        public string Connected { get; set; }

        [JsonProperty("Available")]
        public string Available { get; set; }
    }
}