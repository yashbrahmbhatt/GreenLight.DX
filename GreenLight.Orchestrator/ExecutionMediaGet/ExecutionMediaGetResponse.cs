using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ExecutionMediaGetResponse
    {
        [JsonProperty("value")]
        public List<Value11> Value { get; set; }
    }

    public class Value11
    {
        [JsonProperty("StorageLocation")]
        public string StorageLocation { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("JobId")]
        public string JobId { get; set; }

        [JsonProperty("ReleaseName")]
        public string ReleaseName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}