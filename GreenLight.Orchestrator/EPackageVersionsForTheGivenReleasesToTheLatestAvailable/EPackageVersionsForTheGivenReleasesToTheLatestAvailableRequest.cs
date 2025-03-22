using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EPackageVersionsForTheGivenReleasesToTheLatestAvailableRequest
    {
        [JsonProperty("releaseIds")]
        public List<string> ReleaseIds { get; set; }

        [JsonProperty("mergePackageTags")]
        public string MergePackageTags { get; set; }
    }
}