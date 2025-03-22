using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AddsATaskNoteRequest
    {
        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("TaskId")]
        public string TaskId { get; set; }
    }
}