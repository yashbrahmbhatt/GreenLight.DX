using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsAListOfTestCaseDefinitionsResponse
    {
        [JsonProperty("value")]
        public List<Definition> Value { get; set; }
    }
}