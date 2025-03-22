using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TsACredentialStoreAsTheDefaultForTheGivenCredentialTypeRequest
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }
    }
}