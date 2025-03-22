using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetsTheReviewerForMultipleQueueItemsRequest
    {
        [JsonProperty("queueItems")]
        public List<QueueItems> QueueItems { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}