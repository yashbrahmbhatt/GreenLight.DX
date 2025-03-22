using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CompleteTheTaskBySavingTaskDataAndActionTakenRequest
    {
        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}