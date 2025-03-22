using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UpdatesTheCurrentSettingsRequest
    {
        [JsonProperty("settings")]
        public List<Value46> Settings { get; set; }
    }
}