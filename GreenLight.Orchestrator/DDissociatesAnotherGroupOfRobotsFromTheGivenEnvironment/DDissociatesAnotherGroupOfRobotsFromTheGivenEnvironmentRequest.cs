using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DDissociatesAnotherGroupOfRobotsFromTheGivenEnvironmentRequest
    {
        [JsonProperty("addedRobotIds")]
        public List<string> AddedRobotIds { get; set; }

        [JsonProperty("removedRobotIds")]
        public List<string> RemovedRobotIds { get; set; }
    }
}