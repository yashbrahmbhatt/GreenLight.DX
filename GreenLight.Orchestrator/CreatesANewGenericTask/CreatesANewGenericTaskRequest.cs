using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewGenericTaskRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("taskCatalogName")]
        public string TaskCatalogName { get; set; }

        [JsonProperty("externalTag")]
        public string ExternalTag { get; set; }

        [JsonProperty("tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("parentOperationId")]
        public string ParentOperationId { get; set; }
    }
}