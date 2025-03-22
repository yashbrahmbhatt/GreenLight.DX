using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AvailableVersionsOfAGivenPackageAllowsOdataQueryOptionsResponse
    {
        [JsonProperty("value")]
        public List<Value19> Value { get; set; }
    }
}