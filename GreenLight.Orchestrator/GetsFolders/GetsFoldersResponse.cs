using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsFoldersResponse
    {
        [JsonProperty("value")]
        public List<Value12> Value { get; set; }
    }

    public class Value12
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("FullyQualifiedName")]
        public string FullyQualifiedName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("FolderType")]
        public string FolderType { get; set; }

        [JsonProperty("IsPersonal")]
        public string IsPersonal { get; set; }

        [JsonProperty("ProvisionType")]
        public string ProvisionType { get; set; }

        [JsonProperty("PermissionModel")]
        public string PermissionModel { get; set; }

        [JsonProperty("ParentId")]
        public string ParentId { get; set; }

        [JsonProperty("ParentKey")]
        public string ParentKey { get; set; }

        [JsonProperty("FeedType")]
        public string FeedType { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}