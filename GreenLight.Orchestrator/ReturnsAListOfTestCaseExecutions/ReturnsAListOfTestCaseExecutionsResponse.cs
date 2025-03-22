using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsAListOfTestCaseExecutionsResponse
    {
        [JsonProperty("value")]
        public List<PecifiedTestCaseExecutionsWithinTheSameTestSetExecutionResponse> Value { get; set; }
    }
}