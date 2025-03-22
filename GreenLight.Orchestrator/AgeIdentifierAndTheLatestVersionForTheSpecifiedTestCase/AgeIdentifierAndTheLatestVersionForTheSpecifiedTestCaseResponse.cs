using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AgeIdentifierAndTheLatestVersionForTheSpecifiedTestCaseResponse
    {
        [JsonProperty("packageIdentifier")]
        public string PackageIdentifier { get; set; }

        [JsonProperty("latestVersion")]
        public string LatestVersion { get; set; }

        [JsonProperty("latestPrereleaseVersion")]
        public string LatestPrereleaseVersion { get; set; }
    }
}