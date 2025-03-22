using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class UsersAssignRolesByIdRequest
    {
        [JsonProperty("roleIds")]
        public List<string> RoleIds { get; set; }
    }
}