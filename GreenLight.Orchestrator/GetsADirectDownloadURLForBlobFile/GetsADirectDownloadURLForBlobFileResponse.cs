using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsADirectDownloadURLForBlobFileResponse
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

    public class Headers
    {
        [JsonProperty("Keys")]
        public List<string> Keys { get; set; }

        [JsonProperty("Values")]
        public List<string> Values { get; set; }
    }
}