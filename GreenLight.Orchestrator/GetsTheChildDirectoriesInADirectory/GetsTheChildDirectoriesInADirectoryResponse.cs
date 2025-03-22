using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheChildDirectoriesInADirectoryResponse
    {
        [JsonProperty("value")]
        public List<Value4> Value { get; set; }
    }

    public class Value4
    {
        [JsonProperty("FullPath")]
        public string FullPath { get; set; }

        [JsonProperty("ContentType")]
        public string ContentType { get; set; }

        [JsonProperty("Size")]
        public string Size { get; set; }

        [JsonProperty("IsDirectory")]
        public string IsDirectory { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}