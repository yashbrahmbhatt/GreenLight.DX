using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ToggleMachinePropagationForAFolderToAllSubfoldersRequest
    {
        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("FolderId")]
        public string FolderId { get; set; }

        [JsonProperty("InheritEnabled")]
        public string InheritEnabled { get; set; }
    }
}