using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UntOfFoldersWhereItIsSharedIncludingUnaccessibleFoldersResponse
    {
        [JsonProperty("AccessibleFolders")]
        public List<Folder> AccessibleFolders { get; set; }

        [JsonProperty("TotalFoldersCount")]
        public string TotalFoldersCount { get; set; }
    }
}