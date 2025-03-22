using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJobResponse
    {
        [JsonProperty("value")]
        public List<RestartsTheSpecifiedJobResponse> Value { get; set; }
    }
}