using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class EntryPoint
    {
        [JsonProperty("filePath", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; set; }

        [JsonProperty("uniqueId", NullValueHandling = NullValueHandling.Ignore)]
        public string UniqueId { get; set; }

        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Input { get; set; }

        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Output { get; set; }
    }
}
