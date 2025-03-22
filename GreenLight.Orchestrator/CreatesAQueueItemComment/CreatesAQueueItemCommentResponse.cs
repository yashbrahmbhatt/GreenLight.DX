using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesAQueueItemCommentResponse
    {
        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("QueueItemId")]
        public string QueueItemId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}