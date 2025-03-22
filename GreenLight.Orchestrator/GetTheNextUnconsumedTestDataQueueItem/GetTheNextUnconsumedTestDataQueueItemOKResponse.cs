using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetTheNextUnconsumedTestDataQueueItemOKResponse
    {
        [JsonProperty("testDataQueueId")]
        public string TestDataQueueId { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("isConsumed")]
        public string IsConsumed { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}