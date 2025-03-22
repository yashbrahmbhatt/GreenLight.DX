using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class BulkAddsQueueItemsResponse
    {
        [JsonProperty("Success")]
        public string Success { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("FailedItems")]
        public List<FailedItems> FailedItems { get; set; }
    }

    public class FailedItems
    {
        [JsonProperty("Ordinal")]
        public string Ordinal { get; set; }

        [JsonProperty("ErrorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}