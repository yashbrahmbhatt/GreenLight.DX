using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RsWithAndDissociatesAnotherGroupOfUsersFromTheGivenRoleRequest
    {
        [JsonProperty("addedUserIds")]
        public List<string> AddedUserIds { get; set; }

        [JsonProperty("removedUserIds")]
        public List<string> RemovedUserIds { get; set; }
    }
}