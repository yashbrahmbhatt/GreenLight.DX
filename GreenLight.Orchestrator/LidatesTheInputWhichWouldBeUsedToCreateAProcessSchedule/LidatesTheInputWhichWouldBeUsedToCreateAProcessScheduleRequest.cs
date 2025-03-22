using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class LidatesTheInputWhichWouldBeUsedToCreateAProcessScheduleRequest
    {
        [JsonProperty("processSchedule")]
        public CreatesANewProcessScheduleRequest ProcessSchedule { get; set; }
    }
}