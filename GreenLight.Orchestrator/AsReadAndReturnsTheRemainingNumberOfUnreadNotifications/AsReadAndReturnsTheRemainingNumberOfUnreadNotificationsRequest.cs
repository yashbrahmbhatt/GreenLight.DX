using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsRequest
    {
        [JsonProperty("ids")]
        public List<string> Ids { get; set; }
    }
}