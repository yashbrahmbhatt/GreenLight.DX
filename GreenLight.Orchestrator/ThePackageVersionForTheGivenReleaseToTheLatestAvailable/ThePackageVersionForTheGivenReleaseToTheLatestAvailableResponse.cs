using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ThePackageVersionForTheGivenReleaseToTheLatestAvailableResponse
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}