using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsASingleCredentialStoreByItsKeyResponse
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("ProxyId")]
        public string ProxyId { get; set; }

        [JsonProperty("ProxyType")]
        public string ProxyType { get; set; }

        [JsonProperty("HostName")]
        public string HostName { get; set; }

        [JsonProperty("AdditionalConfiguration")]
        public string AdditionalConfiguration { get; set; }

        [JsonProperty("Details")]
        public Details Details { get; set; }

        [JsonProperty("DefaultCredentialStores")]
        public List<DefaultCredentialStores> DefaultCredentialStores { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}