using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RsTheUserHasactuallyBeenAssignedToTheFoldersWillBeMarkeResponse
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("IsSelectable")]
        public string IsSelectable { get; set; }

        [JsonProperty("HasChildren")]
        public string HasChildren { get; set; }

        [JsonProperty("Level")]
        public string Level { get; set; }

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