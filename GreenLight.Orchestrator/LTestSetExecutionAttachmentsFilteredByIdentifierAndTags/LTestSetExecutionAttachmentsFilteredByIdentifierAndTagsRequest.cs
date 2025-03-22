using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class LTestSetExecutionAttachmentsFilteredByIdentifierAndTagsRequest
    {
        [JsonProperty("testSetExecutionId")]
        public string TestSetExecutionId { get; set; }

        [JsonProperty("batchExecutionKey")]
        public string BatchExecutionKey { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}