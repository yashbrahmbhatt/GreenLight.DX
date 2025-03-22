using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ValidatesTaskCatalogDeletionRequestOKResponse
    {
        [JsonProperty("AssociatedTasksCount")]
        public string AssociatedTasksCount { get; set; }

        [JsonProperty("IsEncrypted")]
        public string IsEncrypted { get; set; }

        [JsonProperty("TotalFolderCount")]
        public string TotalFolderCount { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}