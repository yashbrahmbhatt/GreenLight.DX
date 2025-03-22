using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReleaseAcquiredLicenseUnitsRequest
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }
    }
}