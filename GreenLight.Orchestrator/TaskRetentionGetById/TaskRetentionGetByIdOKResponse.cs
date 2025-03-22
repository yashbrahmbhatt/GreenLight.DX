using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TaskRetentionGetByIdOKResponse
    {
        [JsonProperty("TaskCatalogId")]
        public string TaskCatalogId { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("Period")]
        public string Period { get; set; }

        [JsonProperty("BucketId")]
        public string BucketId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}