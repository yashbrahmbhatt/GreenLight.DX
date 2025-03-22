using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EditsACalendarRequest
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("TimeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty("ExcludedDates")]
        public List<string> ExcludedDates { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}