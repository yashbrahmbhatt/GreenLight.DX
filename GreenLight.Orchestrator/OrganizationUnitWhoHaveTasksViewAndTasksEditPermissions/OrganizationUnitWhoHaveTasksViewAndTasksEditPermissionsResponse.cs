using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class OrganizationUnitWhoHaveTasksViewAndTasksEditPermissionsResponse
    {
        [JsonProperty("value")]
        public List<AssignedToUser> Value { get; set; }
    }
}