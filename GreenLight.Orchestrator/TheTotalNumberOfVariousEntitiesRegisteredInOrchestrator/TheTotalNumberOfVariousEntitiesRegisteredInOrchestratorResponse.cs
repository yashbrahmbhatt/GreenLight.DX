using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TheTotalNumberOfVariousEntitiesRegisteredInOrchestratorResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("hasPermissions")]
        public string HasPermissions { get; set; }
    }
}