using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AsTestSetExecutionsViewIfThereIsNoneWillReturnForbiddenResponse
    {
        [JsonProperty("value")]
        public List<TestSetExecution> Value { get; set; }
    }
}