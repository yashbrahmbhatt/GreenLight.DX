using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheMachineChangesWhenMovingAFolderResponse
    {
        [JsonProperty("value")]
        public List<Value14> Value { get; set; }
    }

    public class Value14
    {
        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("OldMachineFolderState")]
        public string OldMachineFolderState { get; set; }

        [JsonProperty("NewMachineFolderState")]
        public string NewMachineFolderState { get; set; }
    }
}