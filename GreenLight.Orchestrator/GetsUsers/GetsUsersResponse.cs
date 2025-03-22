using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsUsersResponse
    {
        [JsonProperty("value")]
        public List<Value26> Value { get; set; }
    }
}