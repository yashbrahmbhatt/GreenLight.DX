using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnASpecificTestDataQueueItemIdentifiedByKeyResponse
    {
        [JsonProperty("TestDataQueueId")]
        public string TestDataQueueId { get; set; }

        [JsonProperty("ContentJson")]
        public string ContentJson { get; set; }

        [JsonProperty("IsConsumed")]
        public string IsConsumed { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}