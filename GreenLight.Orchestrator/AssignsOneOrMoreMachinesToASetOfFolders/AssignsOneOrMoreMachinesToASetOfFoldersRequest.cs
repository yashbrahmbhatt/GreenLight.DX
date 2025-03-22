using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AssignsOneOrMoreMachinesToASetOfFoldersRequest
    {
        [JsonProperty("assignments")]
        public Assignments Assignments { get; set; }
    }

    public class Assignments
    {
        [JsonProperty("MachineIds")]
        public List<string> MachineIds { get; set; }

        [JsonProperty("FolderIds")]
        public List<string> FolderIds { get; set; }
    }
}