using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class DesignOptions
    {
        [JsonProperty("projectProfile", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectProfile { get; set; }

        [JsonProperty("outputType", NullValueHandling = NullValueHandling.Ignore)]
        public string OutputType { get; set; }

        [JsonProperty("libraryOptions", NullValueHandling = NullValueHandling.Ignore)]
        public LibraryOptions LibraryOptions { get; set; }

        [JsonProperty("processOptions", NullValueHandling = NullValueHandling.Ignore)]
        public ProcessOptions ProcessOptions { get; set; }

        [JsonProperty("fileInfoCollection", NullValueHandling = NullValueHandling.Ignore)]
        public List<FileInfoCollection> FileInfoCollection { get; set; }

        [JsonProperty("saveToCloud", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SaveToCloud { get; set; }
    }
}
