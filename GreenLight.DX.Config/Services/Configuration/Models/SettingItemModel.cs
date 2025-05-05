using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GreenLight.DX.Config.Services.Configuration.Models
{
    [Serializable]
    [XmlType(nameof(SettingItemModel))] // For XML serialization of derived type
    public class SettingItemModel : ConfigItemModel
    {
        [JsonProperty(nameof(StringValue))]
        public string StringValue { get; set; } = "Value";

        [JsonIgnore]
        [XmlIgnore]
        public override object Value
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
        public SettingItemModel() : base() { }
        public SettingItemModel(IServiceProvider services) : base(services) { }

        public new void InitializeServices(IServiceProvider provider)
        {
            base.InitializeServices(provider);
        }
    }
}
