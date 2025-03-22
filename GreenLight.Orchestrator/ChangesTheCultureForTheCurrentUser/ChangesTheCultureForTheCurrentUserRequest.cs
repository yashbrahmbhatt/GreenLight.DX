using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ChangesTheCultureForTheCurrentUserRequest
    {
        [JsonProperty("culture")]
        public string Culture { get; set; }
    }
}