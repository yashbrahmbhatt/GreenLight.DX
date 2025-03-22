using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsMachineRuntimeSessionsByFolderIdResponse
    {
        [JsonProperty("value")]
        public List<Value44> Value { get; set; }
    }
}