using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReatedAsARetryOfAFailedQueueItemTheyAlsoShareTheSameKeyResponse
    {
        [JsonProperty("value")]
        public List<CreatesAQueueItemCommentRequest> Value { get; set; }
    }
}