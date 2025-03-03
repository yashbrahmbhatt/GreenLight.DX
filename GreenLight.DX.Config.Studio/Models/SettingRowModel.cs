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
    [XmlType(nameof(SettingRowModel))] // For XML serialization of derived type
    public class SettingRowModel : ConfigurationRowModel
    {
        [JsonProperty(nameof(Value))] // Use nameof
        public string Value { get; set; } = "Value";

        public SettingRowModel() : base() { }
    }
}
