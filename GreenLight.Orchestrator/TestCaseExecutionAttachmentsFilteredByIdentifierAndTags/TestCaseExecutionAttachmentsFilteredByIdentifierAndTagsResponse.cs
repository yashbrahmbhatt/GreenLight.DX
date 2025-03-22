using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TestCaseExecutionAttachmentsFilteredByIdentifierAndTagsResponse
    {
        [JsonProperty("TestCaseExecutionId")]
        public string TestCaseExecutionId { get; set; }

        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("MimeType")]
        public string MimeType { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}