using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsJobTriggersResponse
    {
        [JsonProperty("value")]
        public List<Value17> Value { get; set; }
    }

    public class Value17
    {
        [JsonProperty("JobId")]
        public string JobId { get; set; }

        [JsonProperty("TriggerType")]
        public string TriggerType { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("ItemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("ItemId")]
        public string ItemId { get; set; }

        [JsonProperty("Timer")]
        public string Timer { get; set; }

        [JsonProperty("TriggerMessage")]
        public string TriggerMessage { get; set; }

        [JsonProperty("TriggerConfiguration")]
        public string TriggerConfiguration { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}