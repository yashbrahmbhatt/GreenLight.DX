using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReUsersToASetOfFoldersWithAnOptionalSetOfRolesPerFolderRequest
    {
        [JsonProperty("assignments")]
        public Assignments2 Assignments { get; set; }
    }

    public class Assignments2
    {
        [JsonProperty("UserIds")]
        public List<string> UserIds { get; set; }

        [JsonProperty("RolesPerFolder")]
        public List<RolesPerFolder> RolesPerFolder { get; set; }
    }
}