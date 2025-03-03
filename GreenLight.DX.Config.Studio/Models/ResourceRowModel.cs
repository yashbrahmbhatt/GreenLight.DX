using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GreenLight.DX.Config.Studio.Models
{
    [Serializable]
    [XmlType(nameof(ResourceRowModel))] // For XML serialization of derived type
    public class ResourceRowModel : ConfigurationRowModel
    {
        [JsonProperty(nameof(Path))] // Use nameof
        public string Path { get; set; } = "Path";

        [JsonProperty(nameof(Folder))] // Use nameof
        public string Folder { get; set; } = "Folder";

        [JsonProperty(nameof(Bucket))] // Use nameof
        public string Bucket { get; set; } = "Bucket";

        public ResourceRowModel() : base()
        {
        }
    }
}
