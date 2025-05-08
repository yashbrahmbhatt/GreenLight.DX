using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class LibraryOptions
    {
        [JsonProperty("includeOriginalXaml", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeOriginalXaml { get; set; }

        [JsonProperty("privateWorkflows", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> PrivateWorkflows { get; set; }
    }
}
