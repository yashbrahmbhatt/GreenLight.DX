using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class IntUsedForTestingConnectivityAndAvailabilityOfTargetURLResponse
    {
        [JsonProperty("EventId")]
        public string EventId { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("EntityKey")]
        public string EntityKey { get; set; }

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
}