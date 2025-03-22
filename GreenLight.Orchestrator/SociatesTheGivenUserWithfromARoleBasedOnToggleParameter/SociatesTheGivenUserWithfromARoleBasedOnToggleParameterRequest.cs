using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SociatesTheGivenUserWithfromARoleBasedOnToggleParameterRequest
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("toggle")]
        public string Toggle { get; set; }
    }
}