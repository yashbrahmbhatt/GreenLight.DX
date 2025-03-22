using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AddANewTestDataQueueItemRequest
    {
        [JsonProperty("queueName")]
        public string QueueName { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public class Content
    {
    }
}