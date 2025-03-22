using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UpdatesThePackageVersionForTheGivenReleaseRequest
    {
        [JsonProperty("packageVersion")]
        public string PackageVersion { get; set; }
    }
}