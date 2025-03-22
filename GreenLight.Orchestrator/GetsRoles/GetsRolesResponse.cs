using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsRolesResponse
    {
        [JsonProperty("value")]
        public List<Value42> Value { get; set; }
    }

    public class Value42
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Groups")]
        public string Groups { get; set; }

        [JsonProperty("IsStatic")]
        public string IsStatic { get; set; }

        [JsonProperty("IsEditable")]
        public string IsEditable { get; set; }

        [JsonProperty("Permissions")]
        public List<Value27> Permissions { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}