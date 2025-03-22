using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetsTheGivenQueueItemsStatusToDeletedRequest
    {
        [JsonProperty("queueItems")]
        public List<QueueItems> QueueItems { get; set; }
    }

    public class QueueItems
    {
        [JsonProperty("RowVersion")]
        public string RowVersion { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}