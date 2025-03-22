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
    [XmlType(nameof(SettingItem))] // For XML serialization of derived type
    public class SettingItem : ConfigItem
    {
        [JsonProperty(nameof(StringValue))]
        public string StringValue { get; set; } = "Value";

        [JsonIgnore]
        [XmlIgnore]
        public override object? Value
        {
            get
            {
                if (ValueType == null)
                {
                    return StringValue;
                }
                else
                {
                    return _typeParserService.Parse(StringValue, ValueType);
                }
            }
            set => throw new InvalidOperationException("Cannot set value for AssetItem");
        }
        public SettingItem() : base() { }
        public SettingItem(IServiceProvider services) : base(services) { }

        public new void InitializeServices(IServiceProvider provider)
        {
            base.InitializeServices(provider);
        }
    }
}
