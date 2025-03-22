using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsPersonalWorkspaceForCurrentUserOKResponse
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("OwnerId")]
        public string OwnerId { get; set; }

        [JsonProperty("OwnerKey")]
        public string OwnerKey { get; set; }

        [JsonProperty("OwnerName")]
        public string OwnerName { get; set; }

        [JsonProperty("LastLogin")]
        public string LastLogin { get; set; }

        [JsonProperty("ExploringUserIds")]
        public List<string> ExploringUserIds { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}