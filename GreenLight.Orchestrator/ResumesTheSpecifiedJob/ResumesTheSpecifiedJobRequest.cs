using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ResumesTheSpecifiedJobRequest
    {
        [JsonProperty("jobKey")]
        public string JobKey { get; set; }
    }
}