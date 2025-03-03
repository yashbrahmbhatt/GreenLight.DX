using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace GreenLight.DX.Config.Studio.Models
{
    [Serializable]
    [XmlType(nameof(AssetRowModel))] // For XML serialization of derived type
    public class AssetRowModel : ConfigurationRowModel
    {
        [JsonProperty(nameof(AssetName))]
        public string AssetName { get; set; } = "AssetName";

        [JsonProperty(nameof(AssetFolder))]
        public string AssetFolder { get; set; } = "AssetFolder";

        public AssetRowModel() : base()
        {
        }

    }
}