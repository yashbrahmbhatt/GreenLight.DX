using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequestResponse
    {
        [JsonProperty("value")]
        public List<Value20> Value { get; set; }
    }

    public class Value20
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }
    }
}