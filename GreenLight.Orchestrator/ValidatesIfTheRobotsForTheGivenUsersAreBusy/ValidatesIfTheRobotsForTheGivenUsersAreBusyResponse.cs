using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ValidatesIfTheRobotsForTheGivenUsersAreBusyResponse
    {
        [JsonProperty("value")]
        public Value59 Value { get; set; }
    }

    public class Value59
    {
        [JsonProperty("iruref0")]
        public string Iruref0 { get; set; }

        [JsonProperty("proident4d")]
        public string Proident4d { get; set; }

        [JsonProperty("sint__0b")]
        public string Sint0b { get; set; }

        [JsonProperty("labore74a")]
        public string Labore74a { get; set; }
    }
}