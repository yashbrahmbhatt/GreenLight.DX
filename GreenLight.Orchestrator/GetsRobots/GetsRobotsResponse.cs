using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsRobotsResponse
    {
        [JsonProperty("value")]
        public List<Robots> Value { get; set; }
    }
}