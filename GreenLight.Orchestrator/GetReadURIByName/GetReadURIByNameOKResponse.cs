using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetReadURIByNameOKResponse
    {
        [JsonProperty("VersionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("BusinessRuleName")]
        public string BusinessRuleName { get; set; }

        [JsonProperty("DownloadUri")]
        public GetsADirectDownloadURLForBlobFileResponse DownloadUri { get; set; }
    }
}