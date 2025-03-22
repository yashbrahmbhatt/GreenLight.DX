using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class LtValuesWillBeTheActualValuesSetGloballyegResolutionWidResponse
    {
        [JsonProperty("Scope")]
        public string Scope { get; set; }

        [JsonProperty("Configuration")]
        public List<Configuration> Configuration { get; set; }
    }

    public class Configuration
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("ValueType")]
        public string ValueType { get; set; }

        [JsonProperty("DefaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty("PossibleValues")]
        public List<string> PossibleValues { get; set; }
    }
}