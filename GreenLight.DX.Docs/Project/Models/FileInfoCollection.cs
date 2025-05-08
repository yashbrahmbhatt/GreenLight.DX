using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class FileInfoCollection
    {
        [JsonProperty("templateType", NullValueHandling = NullValueHandling.Ignore)]
        public string? TemplateType { get; set; }

        [JsonProperty("fileName", NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty("editingStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? EditingStatus { get; set; }

        [JsonProperty("testCaseId", NullValueHandling = NullValueHandling.Ignore)]
        public string? TestCaseId { get; set; }

        [JsonProperty("testCaseType", NullValueHandling = NullValueHandling.Ignore)]
        public string? TestCaseType { get; set; }
    }
}
