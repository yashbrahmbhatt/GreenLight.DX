using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DeletesTheExecutionMediaForTheGivenJobKeyRequest
    {
        [JsonProperty("jobId")]
        public string JobId { get; set; }
    }
}