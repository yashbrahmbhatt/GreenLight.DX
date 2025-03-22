using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TaskRetentionGetResponse
    {
        [JsonProperty("value")]
        public List<Value51> Value { get; set; }
    }

    public class Value51
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