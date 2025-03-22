using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EtsCustomCalendarWithExcludedDatesInUTCForCurrentTenantResponse
    {
        [JsonProperty("TimeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty("ExcludedDates")]
        public List<string> ExcludedDates { get; set; }
    }
}