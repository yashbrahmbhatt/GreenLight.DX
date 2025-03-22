using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsMachinesAssignedToFolderAndRobotResponse
    {
        [JsonProperty("value")]
        public List<CreatesANewMachineResponse> Value { get; set; }
    }
}