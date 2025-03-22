using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewTaskCatalogRequest
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Encrypted")]
        public string Encrypted { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("RetentionAction")]
        public string RetentionAction { get; set; }

        [JsonProperty("RetentionPeriod")]
        public string RetentionPeriod { get; set; }

        [JsonProperty("RetentionBucketId")]
        public string RetentionBucketId { get; set; }
    }
}