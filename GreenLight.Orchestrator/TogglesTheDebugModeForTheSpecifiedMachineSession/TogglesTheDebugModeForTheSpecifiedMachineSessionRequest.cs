using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TogglesTheDebugModeForTheSpecifiedMachineSessionRequest
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("minutes")]
        public string Minutes { get; set; }
    }
}