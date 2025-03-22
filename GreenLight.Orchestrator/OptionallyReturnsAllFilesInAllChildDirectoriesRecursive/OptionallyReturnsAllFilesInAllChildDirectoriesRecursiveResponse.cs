using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class OptionallyReturnsAllFilesInAllChildDirectoriesRecursiveResponse
    {
        [JsonProperty("value")]
        public List<GetsAFileMetadataResponse> Value { get; set; }
    }
}