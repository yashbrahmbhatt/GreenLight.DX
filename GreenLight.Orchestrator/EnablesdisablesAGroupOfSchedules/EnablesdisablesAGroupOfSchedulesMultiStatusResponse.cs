using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EnablesdisablesAGroupOfSchedulesMultiStatusResponse
    {
        [JsonProperty("eu_9")]
        public Eu9 Eu9 { get; set; }

        [JsonProperty("ut_c43")]
        public Eu9 UtC43 { get; set; }
    }

    public class Eu9
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