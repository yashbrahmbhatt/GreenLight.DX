using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2OKResponse
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
}