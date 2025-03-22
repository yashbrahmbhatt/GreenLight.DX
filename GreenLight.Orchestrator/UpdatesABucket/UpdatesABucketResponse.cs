using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UpdatesABucketResponse
    {
        [JsonProperty("Identifier")]
        public string Identifier { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("StorageProvider")]
        public string StorageProvider { get; set; }

        [JsonProperty("StorageParameters")]
        public string StorageParameters { get; set; }

        [JsonProperty("StorageContainer")]
        public string StorageContainer { get; set; }

        [JsonProperty("Options")]
        public string Options { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("ExternalName")]
        public string ExternalName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("FoldersCount")]
        public string FoldersCount { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}