using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUser2Response
    {
        [JsonProperty("TenantRoles")]
        public List<Roles2> TenantRoles { get; set; }

        [JsonProperty("PageItems")]
        public List<PageItems2> PageItems { get; set; }

        [JsonProperty("Count")]
        public string Count { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}