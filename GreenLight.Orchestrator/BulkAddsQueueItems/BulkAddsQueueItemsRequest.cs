using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class BulkAddsQueueItemsRequest
    {
        [JsonProperty("commitType")]
        public string CommitType { get; set; }

        [JsonProperty("queueName")]
        public string QueueName { get; set; }

        [JsonProperty("queueItems")]
        public List<UpdatesTheQueueItemPropertiesWithTheNewValuesProvidedRequest> QueueItems { get; set; }
    }

    public class Consectetur0
    {
    }

    public class Duis19
    {
    }

    public class EuE
    {
    }

    public class Fugiatfab
    {
    }
}