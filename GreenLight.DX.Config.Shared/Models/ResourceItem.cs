using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GreenLight.DX.Config.Shared.Models
{
    [Serializable]
    [XmlType(nameof(ResourceItem))] // For XML serialization of derived type
    public class ResourceItem : ConfigItem
    {
        [JsonProperty(nameof(Path))] // Use nameof
        public string Path { get; set; } = "Path";

        [JsonProperty(nameof(Folder))] // Use nameof
        public string Folder { get; set; } = "Folder";

        [JsonProperty(nameof(Bucket))] // Use nameof
        public string Bucket { get; set; } = "Bucket";

        [JsonProperty(nameof(ResourceType))]
        public ResourceRowType ResourceType { get; set; } = ResourceRowType.LocalOrNetwork;

        public ResourceItem() : base()
        {
        }
    }

    public enum ResourceRowType
    {
        LocalOrNetwork,
        Orchestrator
    }
}
