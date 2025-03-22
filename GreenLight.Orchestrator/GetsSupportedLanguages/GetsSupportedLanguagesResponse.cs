using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsSupportedLanguagesResponse
    {
        [JsonProperty("Items")]
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("IsDefault")]
        public string IsDefault { get; set; }

        [JsonProperty("IsDisabled")]
        public string IsDisabled { get; set; }
    }
}