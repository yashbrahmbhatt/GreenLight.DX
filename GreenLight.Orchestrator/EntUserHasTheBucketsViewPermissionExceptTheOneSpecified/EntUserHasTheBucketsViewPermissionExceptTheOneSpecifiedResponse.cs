using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class EntUserHasTheBucketsViewPermissionExceptTheOneSpecifiedResponse
    {
        [JsonProperty("value")]
        public List<CreatesAnBucketRequest> Value { get; set; }
    }
}