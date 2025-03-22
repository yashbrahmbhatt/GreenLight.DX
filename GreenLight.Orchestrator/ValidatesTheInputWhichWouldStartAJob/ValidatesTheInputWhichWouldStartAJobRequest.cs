using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ValidatesTheInputWhichWouldStartAJobRequest
    {
        [JsonProperty("startInfo")]
        public StartInfo StartInfo { get; set; }
    }
}