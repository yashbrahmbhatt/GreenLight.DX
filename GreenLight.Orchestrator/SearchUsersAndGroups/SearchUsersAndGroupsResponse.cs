using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SearchUsersAndGroupsResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("identityName")]
        public string IdentityName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}