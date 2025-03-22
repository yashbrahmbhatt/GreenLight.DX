using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EReviewStatusOfTheSpecifiedQueueItemsToAnIndicatedStateRequest
    {
        [JsonProperty("queueItems")]
        public List<QueueItems> QueueItems { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}