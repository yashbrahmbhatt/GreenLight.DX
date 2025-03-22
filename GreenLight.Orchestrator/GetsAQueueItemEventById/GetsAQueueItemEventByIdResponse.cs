using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsAQueueItemEventByIdResponse
    {
        [JsonProperty("QueueItemId")]
        public string QueueItemId { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("ReviewStatus")]
        public string ReviewStatus { get; set; }

        [JsonProperty("ReviewerUserId")]
        public string ReviewerUserId { get; set; }

        [JsonProperty("ReviewerUserName")]
        public string ReviewerUserName { get; set; }

        [JsonProperty("ExternalClientId")]
        public string ExternalClientId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}