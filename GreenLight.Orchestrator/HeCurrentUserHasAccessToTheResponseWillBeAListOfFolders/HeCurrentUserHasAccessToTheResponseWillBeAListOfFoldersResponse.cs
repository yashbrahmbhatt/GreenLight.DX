using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class HeCurrentUserHasAccessToTheResponseWillBeAListOfFoldersResponse
    {
        [JsonProperty("PageItems")]
        public List<PageItems> PageItems { get; set; }

        [JsonProperty("Count")]
        public string Count { get; set; }
    }

    public class PageItems
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("FullyQualifiedName")]
        public string FullyQualifiedName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("FolderType")]
        public string FolderType { get; set; }

        [JsonProperty("ParentId")]
        public string ParentId { get; set; }

        [JsonProperty("ParentKey")]
        public string ParentKey { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}