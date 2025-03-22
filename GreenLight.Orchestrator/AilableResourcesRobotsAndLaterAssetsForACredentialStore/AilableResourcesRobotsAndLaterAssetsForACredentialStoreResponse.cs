using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AilableResourcesRobotsAndLaterAssetsForACredentialStoreResponse
    {
        [JsonProperty("value")]
        public List<Value8> Value { get; set; }
    }

    public class Value8
    {
        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("CredentialStoreName")]
        public string CredentialStoreName { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}