using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTaskNotesForATaskResponse
    {
        [JsonProperty("value")]
        public List<AddsATaskNoteResponse> Value { get; set; }
    }
}