using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheOrganizationUnitsResponse
    {
        [JsonProperty("value")]
        public List<Value25> Value { get; set; }
    }

    public class Value25
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}