using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SerHasTaskAdminPermissionsWithTheGivenODataQueryOptionsResponse
    {
        [JsonProperty("value")]
        public List<GetsATaskWithTheGivenGuidOKResponse> Value { get; set; }
    }
}