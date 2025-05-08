using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class ProcessOptions
    {
        [JsonProperty("ignoredFiles", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> IgnoredFiles { get; set; }
    }
}
