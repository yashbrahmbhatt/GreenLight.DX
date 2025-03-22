using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EditsTheMetadataOfATaskRequest
    {
        [JsonProperty("TaskId")]
        public string TaskId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("TaskCatalogId")]
        public string TaskCatalogId { get; set; }

        [JsonProperty("UnsetTaskCatalog")]
        public string UnsetTaskCatalog { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("NoteText")]
        public string NoteText { get; set; }
    }
}