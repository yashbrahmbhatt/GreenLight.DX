using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetTheIsConsumedFlagForAllItemsFromATestDataQueueRequest
    {
        [JsonProperty("isConsumed")]
        public string IsConsumed { get; set; }

        [JsonProperty("queueName")]
        public string QueueName { get; set; }
    }
}