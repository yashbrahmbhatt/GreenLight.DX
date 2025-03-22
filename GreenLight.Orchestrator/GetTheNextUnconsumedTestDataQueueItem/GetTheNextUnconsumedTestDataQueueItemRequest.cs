using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetTheNextUnconsumedTestDataQueueItemRequest
    {
        [JsonProperty("queueName")]
        public string QueueName { get; set; }

        [JsonProperty("setConsumed")]
        public string SetConsumed { get; set; }
    }
}