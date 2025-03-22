using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RemoveUserAssignmentFromAFolder3Request
    {
        [JsonProperty("userKey")]
        public string UserKey { get; set; }
    }
}