using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ActivateOrDeactivateAUserRequest
    {
        [JsonProperty("active")]
        public string Active { get; set; }
    }
}