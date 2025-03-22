using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsASingleWebhookResponse
    {
        [JsonProperty("AllowInsecureSsl")]
        public string AllowInsecureSsl { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SubscribeToAllEvents")]
        public string SubscribeToAllEvents { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Secret")]
        public string Secret { get; set; }

        [JsonProperty("Events")]
        public List<Events> Events { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}