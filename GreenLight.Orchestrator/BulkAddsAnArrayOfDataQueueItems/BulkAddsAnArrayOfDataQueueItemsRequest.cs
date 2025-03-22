using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class BulkAddsAnArrayOfDataQueueItemsRequest
    {
        [JsonProperty("items")]
        public List<object> Items { get; set; }

        [JsonProperty("queueName")]
        public string QueueName { get; set; }
    }
}