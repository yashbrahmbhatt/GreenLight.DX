using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DeletesTheTasksRequest
    {
        [JsonProperty("taskIds")]
        public List<string> TaskIds { get; set; }
    }
}