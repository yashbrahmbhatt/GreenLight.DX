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

        public SettingItem() : base() { }
    }
}
