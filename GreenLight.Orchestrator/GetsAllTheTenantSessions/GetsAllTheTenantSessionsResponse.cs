using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsAllTheTenantSessionsResponse
    {
        [JsonProperty("value")]
        public List<Value43> Value { get; set; }
    }
}