using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RemoveUserAssignmentFromAFolder2Request
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}