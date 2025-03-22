using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class OrGroupToASetOfFoldersWithAnOptionalSetOfRolesPerFolderRequest
    {
        [JsonProperty("assignment")]
        public Assignment Assignment { get; set; }
    }

    public class Assignment
    {
        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("DirectoryIdentifier")]
        public string DirectoryIdentifier { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }

        [JsonProperty("RolesPerFolder")]
        public List<RolesPerFolder> RolesPerFolder { get; set; }
    }

    public class RolesPerFolder
    {
        [JsonProperty("FolderId")]
        public string FolderId { get; set; }

        [JsonProperty("RoleIds")]
        public List<string> RoleIds { get; set; }
    }
}