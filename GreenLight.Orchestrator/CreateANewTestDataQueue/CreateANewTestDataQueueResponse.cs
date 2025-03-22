using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreateANewTestDataQueueResponse
    {
        [JsonProperty("ContentJsonSchema")]
        public string ContentJsonSchema { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ItemsCount")]
        public string ItemsCount { get; set; }

        [JsonProperty("ConsumedItemsCount")]
        public string ConsumedItemsCount { get; set; }

        [JsonProperty("IsDeleted")]
        public string IsDeleted { get; set; }

        [JsonProperty("DeleterUserId")]
        public string DeleterUserId { get; set; }

        [JsonProperty("DeletionTime")]
        public string DeletionTime { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}