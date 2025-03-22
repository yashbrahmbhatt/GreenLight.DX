using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class IonOfAllRobotsThatCanExecuteTheProcessWithTheProvidedIdResponse
    {
        [JsonProperty("value")]
        public List<CreatesANewRobotRequest> Value { get; set; }
    }
}