using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetProcessParametersResponse
    {
        [JsonProperty("Input")]
        public string Input { get; set; }

        [JsonProperty("Output")]
        public string Output { get; set; }
    }
}