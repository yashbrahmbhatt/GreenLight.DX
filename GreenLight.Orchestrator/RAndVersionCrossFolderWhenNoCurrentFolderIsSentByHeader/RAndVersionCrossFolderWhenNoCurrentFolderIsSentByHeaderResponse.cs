using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RAndVersionCrossFolderWhenNoCurrentFolderIsSentByHeaderResponse
    {
        [JsonProperty("releaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("versionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("organizationUnitId")]
        public string OrganizationUnitId { get; set; }
    }
}