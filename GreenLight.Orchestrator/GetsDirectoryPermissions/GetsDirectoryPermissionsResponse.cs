using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsDirectoryPermissionsResponse
    {
        [JsonProperty("directoryGroup")]
        public string DirectoryGroup { get; set; }

        [JsonProperty("organizationUnits")]
        public List<OrganizationUnits> OrganizationUnits { get; set; }

        [JsonProperty("roles")]
        public List<Roles> Roles { get; set; }
    }

    public class Roles
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("groups")]
        public string Groups { get; set; }

        [JsonProperty("isStatic")]
        public string IsStatic { get; set; }

        [JsonProperty("isEditable")]
        public string IsEditable { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class OrganizationUnits
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("organizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("organizationUnitName")]
        public string OrganizationUnitName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}