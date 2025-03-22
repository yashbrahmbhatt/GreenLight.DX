using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CancelsOrTerminatesTheSpecifiedJobRequest
    {
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}