using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsAuditLogDetailsByAuditLogIdResponse
    {
        [JsonProperty("value")]
        public List<Entities> Value { get; set; }
    }
}