using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UnsetsTheReviewerForMultipleQueueItemsRequest
    {
        [JsonProperty("queueItems")]
        public List<QueueItems> QueueItems { get; set; }
    }
}