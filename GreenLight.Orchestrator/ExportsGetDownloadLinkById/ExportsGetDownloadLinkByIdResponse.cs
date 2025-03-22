using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ExportsGetDownloadLinkByIdResponse
    {
        [JsonProperty("Uri")]
        public string Uri { get; set; }

        [JsonProperty("Verb")]
        public string Verb { get; set; }

        [JsonProperty("RequiresAuth")]
        public string RequiresAuth { get; set; }

        [JsonProperty("Headers")]
        public Headers Headers { get; set; }
    }
}