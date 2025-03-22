using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsUsernames2Response
    {
        [JsonProperty("value")]
        public List<string> Value { get; set; }
    }
}