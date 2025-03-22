using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AvailableVersionsOfAGivenProcessAllowsOdataQueryOptionsResponse
    {
        [JsonProperty("value")]
        public List<Value29> Value { get; set; }
    }
}