using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DeletesDisconnectedOrUnresponsiveSessionsRequest
    {
        [JsonProperty("sessionIds")]
        public List<string> SessionIds { get; set; }
    }
}