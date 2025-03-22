using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AddAndRemoveMachineAssociationsToAFolderRequest
    {
        [JsonProperty("associations")]
        public Associations Associations { get; set; }
    }

    public class Associations
    {
        [JsonProperty("FolderId")]
        public string FolderId { get; set; }

        [JsonProperty("AddedMachineIds")]
        public List<string> AddedMachineIds { get; set; }

        [JsonProperty("RemovedMachineIds")]
        public List<string> RemovedMachineIds { get; set; }
    }
}