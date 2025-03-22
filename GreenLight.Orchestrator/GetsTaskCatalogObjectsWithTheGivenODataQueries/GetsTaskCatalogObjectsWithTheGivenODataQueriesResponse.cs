using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTaskCatalogObjectsWithTheGivenODataQueriesResponse
    {
        [JsonProperty("value")]
        public List<Value49> Value { get; set; }
    }

    public class Value49
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("FoldersCount")]
        public string FoldersCount { get; set; }

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

        [JsonProperty("RetentionBucketName")]
        public string RetentionBucketName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}