using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class OssFoldersHavingGivenPermissionWithTheGivenODataQueriesResponse
    {
        [JsonProperty("value")]
        public List<CreatesANewTaskCatalogResponse> Value { get; set; }
    }
}