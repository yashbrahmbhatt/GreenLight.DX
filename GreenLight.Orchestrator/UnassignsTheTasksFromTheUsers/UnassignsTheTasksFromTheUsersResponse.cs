using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UnassignsTheTasksFromTheUsersResponse
    {
        [JsonProperty("value")]
        public List<Value53> Value { get; set; }
    }
}