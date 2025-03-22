using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DeletesValuesForTheSpecifiedSettingsInTheTenantScopeRequest
    {
        [JsonProperty("settingNames")]
        public List<string> SettingNames { get; set; }
    }
}