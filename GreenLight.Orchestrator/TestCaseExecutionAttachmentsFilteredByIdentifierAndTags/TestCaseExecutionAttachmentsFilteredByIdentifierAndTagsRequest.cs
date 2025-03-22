using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TestCaseExecutionAttachmentsFilteredByIdentifierAndTagsRequest
    {
        [JsonProperty("testCaseExecutionId")]
        public string TestCaseExecutionId { get; set; }

        [JsonProperty("jobKey")]
        public string JobKey { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}