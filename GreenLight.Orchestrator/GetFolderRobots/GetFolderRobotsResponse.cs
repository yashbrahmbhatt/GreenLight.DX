using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetFolderRobotsResponse
    {
        [JsonProperty("value")]
        public List<Value40> Value { get; set; }
    }
}