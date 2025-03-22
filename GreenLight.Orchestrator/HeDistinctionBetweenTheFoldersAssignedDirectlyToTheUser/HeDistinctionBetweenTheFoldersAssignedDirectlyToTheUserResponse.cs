using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUserResponse
    {
        [JsonProperty("TenantRoles")]
        public List<Roles> TenantRoles { get; set; }

        [JsonProperty("PageItems")]
        public List<PageItems2> PageItems { get; set; }

        [JsonProperty("Count")]
        public string Count { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Users
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("IsInherited")]
        public string IsInherited { get; set; }

        [JsonProperty("AssignedToFolderIds")]
        public List<string> AssignedToFolderIds { get; set; }

        [JsonProperty("MayHaveAttended")]
        public string MayHaveAttended { get; set; }

        [JsonProperty("MayHaveUnattended")]
        public string MayHaveUnattended { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Folder
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("FullyQualifiedName")]
        public string FullyQualifiedName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Roles2
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Users")]
        public List<Users> Users { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class PageItems2
    {
        [JsonProperty("Folder")]
        public Folder Folder { get; set; }

        [JsonProperty("Roles")]
        public List<Roles2> Roles { get; set; }
    }
}