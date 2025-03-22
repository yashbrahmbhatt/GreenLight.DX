using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetFilteredAssetsResponse
    {
        [JsonProperty("value")]
        public List<CreatesAnAssetRequest> Value { get; set; }
    }
}