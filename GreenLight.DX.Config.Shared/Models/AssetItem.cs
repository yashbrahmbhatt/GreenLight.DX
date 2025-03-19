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
    [XmlType(nameof(AssetItem))] // For XML serialization of derived type
    public class AssetItem : ConfigItem
    {
        [JsonProperty(nameof(AssetName))]
        public string AssetName { get; set; } = "AssetName";

        [JsonProperty(nameof(AssetFolder))]
        public string AssetFolder { get; set; } = "AssetFolder";

        public AssetItem() : base()
        {
        }

    }
}
