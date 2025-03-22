using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsTheNamedAssetAssociatedToTheGivenRobotKey2Request
    {
        [JsonProperty("assetName")]
        public string AssetName { get; set; }

        [JsonProperty("robotKey")]
        public string RobotKey { get; set; }

        [JsonProperty("supportsCredentialsProxyDisconnected")]
        public string SupportsCredentialsProxyDisconnected { get; set; }
    }
}