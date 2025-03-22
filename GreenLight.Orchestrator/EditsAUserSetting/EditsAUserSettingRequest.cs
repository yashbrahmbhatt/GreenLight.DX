using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EditsAUserSettingRequest
    {
        [JsonProperty("setting")]
        public Value46 Setting { get; set; }
    }
}