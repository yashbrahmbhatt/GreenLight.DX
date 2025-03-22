using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class OvesTheAssetsFromTheFoldersSpecifiedInToRemoveFolderIdsRequest
    {
        [JsonProperty("AssetIds")]
        public List<string> AssetIds { get; set; }

        [JsonProperty("ToAddFolderIds")]
        public List<string> ToAddFolderIds { get; set; }

        [JsonProperty("ToRemoveFolderIds")]
        public List<string> ToRemoveFolderIds { get; set; }
    }
}