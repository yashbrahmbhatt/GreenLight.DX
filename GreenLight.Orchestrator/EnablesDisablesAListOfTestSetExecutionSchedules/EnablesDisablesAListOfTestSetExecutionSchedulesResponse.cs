using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EnablesDisablesAListOfTestSetExecutionSchedulesResponse
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}