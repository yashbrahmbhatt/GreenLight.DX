using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SaveTagsForATaskRequest
    {
        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        [JsonProperty("tags")]
        public List<Tags> Tags { get; set; }
    }
}