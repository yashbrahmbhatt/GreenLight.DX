using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RequestsACSVExportOfFilteredItems4Response
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("RequestedAt")]
        public string RequestedAt { get; set; }

        [JsonProperty("ExecutedAt")]
        public string ExecutedAt { get; set; }

        [JsonProperty("Size")]
        public string Size { get; set; }
    }
}