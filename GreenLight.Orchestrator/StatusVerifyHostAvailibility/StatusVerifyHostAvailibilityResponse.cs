using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class StatusVerifyHostAvailibilityResponse
    {
        [JsonProperty("canConnect")]
        public string CanConnect { get; set; }

        [JsonProperty("hasBadSsl")]
        public string HasBadSsl { get; set; }

        [JsonProperty("connectionError")]
        public string ConnectionError { get; set; }
    }
}