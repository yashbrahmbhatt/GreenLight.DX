using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheConfigurationFormatForASecureStoreResponse
    {
        [JsonProperty("value")]
        public List<Value47> Value { get; set; }
    }

    public class Value47
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("ValueType")]
        public string ValueType { get; set; }
    }
}