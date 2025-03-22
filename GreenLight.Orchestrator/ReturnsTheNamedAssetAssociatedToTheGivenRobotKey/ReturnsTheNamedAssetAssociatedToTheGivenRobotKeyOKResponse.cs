using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsTheNamedAssetAssociatedToTheGivenRobotKeyOKResponse
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ValueType")]
        public string ValueType { get; set; }

        [JsonProperty("StringValue")]
        public string StringValue { get; set; }

        [JsonProperty("BoolValue")]
        public string BoolValue { get; set; }

        [JsonProperty("IntValue")]
        public string IntValue { get; set; }

        [JsonProperty("CredentialUsername")]
        public string CredentialUsername { get; set; }

        [JsonProperty("CredentialPassword")]
        public string CredentialPassword { get; set; }

        [JsonProperty("ExternalName")]
        public string ExternalName { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("KeyValueList")]
        public List<KeyValueList> KeyValueList { get; set; }

        [JsonProperty("ConnectionData")]
        public ConnectionData ConnectionData { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class ConnectionData
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("bearerToken")]
        public string BearerToken { get; set; }
    }
}