using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetTheIsConsumedFlagForSpecificTestDataQueueItemsRequest
    {
        [JsonProperty("isConsumed")]
        public string IsConsumed { get; set; }

        [JsonProperty("itemIds")]
        public List<string> ItemIds { get; set; }
    }
}