using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RHasTheBusinessRulesViewPermissionExceptTheOneSpecifiedResponse
    {
        [JsonProperty("value")]
        public List<CreateBusinessRuleResponse> Value { get; set; }
    }
}