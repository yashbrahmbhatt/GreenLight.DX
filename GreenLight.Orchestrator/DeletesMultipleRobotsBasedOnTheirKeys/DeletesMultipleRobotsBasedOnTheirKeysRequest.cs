using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DeletesMultipleRobotsBasedOnTheirKeysRequest
    {
        [JsonProperty("robotIds")]
        public List<string> RobotIds { get; set; }
    }
}