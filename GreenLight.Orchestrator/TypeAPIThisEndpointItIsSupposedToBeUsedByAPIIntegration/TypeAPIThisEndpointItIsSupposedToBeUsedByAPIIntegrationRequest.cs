using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TypeAPIThisEndpointItIsSupposedToBeUsedByAPIIntegrationRequest
    {
        [JsonProperty("releaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("versionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("testCaseUniqueIds")]
        public List<string> TestCaseUniqueIds { get; set; }

        [JsonProperty("enableCoverage")]
        public string EnableCoverage { get; set; }

        [JsonProperty("maskBuildVersion")]
        public string MaskBuildVersion { get; set; }
    }
}