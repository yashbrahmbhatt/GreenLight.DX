using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TainingDataAboutTheCurrentUserAndAllThePermissionsItHasOKResponse
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("Permissions")]
        public List<string> Permissions { get; set; }
    }
}