using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetTheAssetValueAssociatedToTheGivenRobotKeyRequest
    {
        [JsonProperty("robotAsset")]
        public ReturnsTheNamedAssetAssociatedToTheGivenRobotIdOKResponse RobotAsset { get; set; }

        [JsonProperty("robotKey")]
        public string RobotKey { get; set; }
    }
}