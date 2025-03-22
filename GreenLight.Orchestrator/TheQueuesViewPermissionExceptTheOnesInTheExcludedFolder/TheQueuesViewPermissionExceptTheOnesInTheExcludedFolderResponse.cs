using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TheQueuesViewPermissionExceptTheOnesInTheExcludedFolderResponse
    {
        [JsonProperty("value")]
        public List<CreatesANewQueueRequest> Value { get; set; }
    }
}