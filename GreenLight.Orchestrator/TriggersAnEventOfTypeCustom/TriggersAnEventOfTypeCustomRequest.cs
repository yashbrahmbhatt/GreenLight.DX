using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TriggersAnEventOfTypeCustomRequest
    {
        [JsonProperty("quis3")]
        public Quis3 Quis3 { get; set; }

        [JsonProperty("none8")]
        public None8 None8 { get; set; }

        [JsonProperty("consequat_a")]
        public ConsequatA ConsequatA { get; set; }
    }

    public class ConsequatA
    {
    }

    public class None8
    {
    }

    public class Quis3
    {
    }
}