using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SaveTaskDataRequest
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("taskId")]
        public string TaskId { get; set; }
    }
}