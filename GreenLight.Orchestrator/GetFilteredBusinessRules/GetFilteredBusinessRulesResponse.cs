using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetFilteredBusinessRulesResponse
    {
        [JsonProperty("value")]
        public List<Value5> Value { get; set; }
    }

    public class Value5
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("CurrentVersion")]
        public CurrentVersion CurrentVersion { get; set; }

        [JsonProperty("FoldersCount")]
        public string FoldersCount { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

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

    public class CurrentVersion
    {
        [JsonProperty("BusinessRuleKey")]
        public string BusinessRuleKey { get; set; }

        [JsonProperty("VersionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}