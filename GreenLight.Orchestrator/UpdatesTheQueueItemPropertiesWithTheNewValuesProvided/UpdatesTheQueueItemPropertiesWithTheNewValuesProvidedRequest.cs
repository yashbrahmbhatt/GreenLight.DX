using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UpdatesTheQueueItemPropertiesWithTheNewValuesProvidedRequest
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("SpecificContent")]
        public SpecificContent3 SpecificContent { get; set; }

        [JsonProperty("DeferDate")]
        public string DeferDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("RiskSlaDate")]
        public string RiskSlaDate { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("Progress")]
        public string Progress { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("ParentOperationId")]
        public string ParentOperationId { get; set; }
    }

    public class SpecificContent3
    {
        [JsonProperty("cillum5")]
        public Cillum5 Cillum5 { get; set; }
    }

    public class Cillum5
    {
    }
}