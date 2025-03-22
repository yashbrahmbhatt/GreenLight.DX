using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TriggersAnEventOfTypeCustomResponse
    {
        [JsonProperty("EventId")]
        public string EventId { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("EntityKey")]
        public string EntityKey { get; set; }

        [JsonProperty("EventData")]
        public EventData EventData { get; set; }

        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("EventSourceId")]
        public string EventSourceId { get; set; }

        [JsonProperty("TenantId")]
        public string TenantId { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("OrganizationUnitKey")]
        public string OrganizationUnitKey { get; set; }

        [JsonProperty("UserKey")]
        public string UserKey { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }
    }

    public class EventData
    {
        [JsonProperty("commodo_ad4")]
        public CommodoAd4 CommodoAd4 { get; set; }
    }

    public class CommodoAd4
    {
    }
}