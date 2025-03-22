using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ConvertsAPersonalWorkspaceToAStandardFolderRequest
    {
        [JsonProperty("folderName")]
        public string FolderName { get; set; }
    }
}