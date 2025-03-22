using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ValidatesAnExistingJobResponse
    {
        [JsonProperty("IsValid")]
        public string IsValid { get; set; }

        [JsonProperty("Errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("ErrorCodes")]
        public List<string> ErrorCodes { get; set; }
    }
}