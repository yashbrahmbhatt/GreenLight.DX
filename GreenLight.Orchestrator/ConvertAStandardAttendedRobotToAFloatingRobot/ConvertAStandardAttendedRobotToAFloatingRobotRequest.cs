using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ConvertAStandardAttendedRobotToAFloatingRobotRequest
    {
        [JsonProperty("robotId")]
        public string RobotId { get; set; }
    }
}