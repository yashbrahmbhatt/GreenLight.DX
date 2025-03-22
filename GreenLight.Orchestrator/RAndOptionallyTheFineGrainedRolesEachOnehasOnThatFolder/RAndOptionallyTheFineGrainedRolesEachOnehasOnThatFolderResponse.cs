using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RAndOptionallyTheFineGrainedRolesEachOnehasOnThatFolderResponse
    {
        [JsonProperty("value")]
        public List<Value15> Value { get; set; }
    }

    public class UserEntity
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("AuthenticationSource")]
        public string AuthenticationSource { get; set; }

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

    public class Roles3
    {
        [JsonProperty("Origin")]
        public string Origin { get; set; }

        [JsonProperty("RoleType")]
        public string RoleType { get; set; }

        [JsonProperty("InheritedFromFolder")]
        public Folder InheritedFromFolder { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Value15
    {
        [JsonProperty("UserEntity")]
        public UserEntity UserEntity { get; set; }

        [JsonProperty("Roles")]
        public List<Roles3> Roles { get; set; }

        [JsonProperty("HasAlertsEnabled")]
        public string HasAlertsEnabled { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}