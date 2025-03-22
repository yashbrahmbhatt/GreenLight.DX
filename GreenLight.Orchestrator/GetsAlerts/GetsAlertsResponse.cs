using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsAlertsResponse
    {
        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public class Value
    {
        [JsonProperty("Severity")]
        public string Severity { get; set; }

        [JsonProperty("NotificationName")]
        public string NotificationName { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }

        [JsonProperty("Component")]
        public string Component { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("UserNotificationId")]
        public string UserNotificationId { get; set; }

        [JsonProperty("DeepLinkRelativeUrl")]
        public string DeepLinkRelativeUrl { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}