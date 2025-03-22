using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsPermissionsResponse
    {
        [JsonProperty("value")]
        public List<Value27> Value { get; set; }
    }

    public class Value27
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsGranted")]
        public string IsGranted { get; set; }

        [JsonProperty("RoleId")]
        public string RoleId { get; set; }

        [JsonProperty("Scope")]
        public string Scope { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}