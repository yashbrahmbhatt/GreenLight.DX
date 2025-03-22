using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EnablesdisablesAGroupOfSchedulesNotFoundResponse
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ErrorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("TraceId")]
        public string TraceId { get; set; }

        [JsonProperty("ResourceIds")]
        public List<string> ResourceIds { get; set; }

        [JsonProperty("Details")]
        public string Details { get; set; }
    }
}