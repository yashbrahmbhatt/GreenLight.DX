using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UnsetsTheReviewerForMultipleQueueItemsResponse
    {
        [JsonProperty("Success")]
        public string Success { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("FailedItems")]
        public List<string> FailedItems { get; set; }
    }
}