using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EssingHistoryOfTheGivenQueueItemAllowsOdataQueryOptionsResponse
    {
        [JsonProperty("value")]
        public List<GetsAQueueItemByIdResponse> Value { get; set; }
    }
}