using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UpdatesThePackageEntryPointForTheGivenReleaseRequest
    {
        [JsonProperty("releaseKey")]
        public string ReleaseKey { get; set; }

        [JsonProperty("processVersion")]
        public string ProcessVersion { get; set; }

        [JsonProperty("entryPointPath")]
        public string EntryPointPath { get; set; }

        [JsonProperty("inputArgs")]
        public string InputArgs { get; set; }
    }
}