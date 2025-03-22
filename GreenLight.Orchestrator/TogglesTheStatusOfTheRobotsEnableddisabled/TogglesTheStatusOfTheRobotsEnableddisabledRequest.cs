using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TogglesTheStatusOfTheRobotsEnableddisabledRequest
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("robotIds")]
        public List<string> RobotIds { get; set; }
    }
}