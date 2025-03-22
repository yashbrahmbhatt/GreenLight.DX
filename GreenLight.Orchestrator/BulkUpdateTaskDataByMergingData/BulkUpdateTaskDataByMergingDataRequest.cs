using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class BulkUpdateTaskDataByMergingDataRequest
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("taskIds")]
        public List<string> TaskIds { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("taskCatalogId")]
        public string TaskCatalogId { get; set; }

        [JsonProperty("unsetTaskCatalog")]
        public string UnsetTaskCatalog { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("noteText")]
        public string NoteText { get; set; }
    }
}