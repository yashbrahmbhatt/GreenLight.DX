using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewTestSetExecutionScheduleRequest
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("TestSetId")]
        public string TestSetId { get; set; }

        [JsonProperty("TimeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("TestSetName")]
        public string TestSetName { get; set; }

        [JsonProperty("TimeZoneIana")]
        public string TimeZoneIana { get; set; }

        [JsonProperty("CalendarId")]
        public string CalendarId { get; set; }

        [JsonProperty("CalendarName")]
        public string CalendarName { get; set; }

        [JsonProperty("CronExpression")]
        public string CronExpression { get; set; }

        [JsonProperty("CronDetails")]
        public string CronDetails { get; set; }

        [JsonProperty("CronSummary")]
        public string CronSummary { get; set; }

        [JsonProperty("NextOccurrence")]
        public string NextOccurrence { get; set; }

        [JsonProperty("DisableDate")]
        public string DisableDate { get; set; }

        [JsonProperty("ExternalJobKey")]
        public string ExternalJobKey { get; set; }

        [JsonProperty("ExternalJobKeyScheduler")]
        public string ExternalJobKeyScheduler { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}