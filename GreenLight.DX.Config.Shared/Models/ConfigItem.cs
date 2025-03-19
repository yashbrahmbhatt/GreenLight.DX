using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GreenLight.DX.Config.Shared.Serializers;

namespace GreenLight.DX.Config.Shared.Models
{
    [Serializable]
    [XmlInclude(typeof(SettingItem))]
    [XmlInclude(typeof(AssetItem))]
    [XmlInclude(typeof(ResourceItem))]
    public abstract class ConfigItem : IXmlSerializable
    {
        [JsonProperty(nameof(Key))]
        public string Key { get; set; } = "Key";

        [JsonProperty(nameof(Description))]
        public string Description { get; set; } = "Description";

        [XmlIgnore]
        [JsonConverter(typeof(TypeSerializer))] // Your custom JSON converter
        public Type ValueType { get; set; } = typeof(string);

        [JsonProperty(nameof(Value))] // Use nameof
        public string Value { get; set; } = "Value";

        public string ToClassString(int indent = 0)
        {
            var indents = new string(' ', indent * 4);
            string typeName;

            if (ValueType == null)
            {
                typeName = "object";
            }
            else if (ValueType.IsPrimitive)
            {
                typeName = ValueType.Name.ToLower(); // Primitives are lowercase in C#
            }
            else if (ValueType == typeof(string))
            {
                typeName = "string";
            }
            else if (ValueType == typeof(DateTime))
            {
                typeName = "DateTime";
            }
            else if (ValueType == typeof(decimal))
            {
                typeName = "decimal";
            }
            else
            {
                typeName = ValueType.Name; // For other types
            }

            var name = Helpers.Strings.ToValidIdentifier(Key);
            var description = string.IsNullOrWhiteSpace(Description) ? "No description" : Description;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{indents}/// <summary>");
            sb.AppendLine($"{indents}/// {description}");
            sb.AppendLine($"{indents}/// </summary>");
            sb.AppendLine($"{indents}public {typeName} {name} {{ get; set; }}\n");
            return sb.ToString();
        }

        // IXmlSerializable Implementation
        public XmlSchema GetSchema() => null; // Not used

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement(); // Move past the element start tag

            Key = reader.GetAttribute("Key");
            Description = reader.GetAttribute("Description");

            string typeName = reader.GetAttribute("ValueType");
            if (!string.IsNullOrEmpty(typeName))
            {
                ValueType = Type.GetType(typeName); // Robust Type.GetType() recommended
            }

            reader.ReadEndElement(); // Move past the element end tag
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Key", Key);
            writer.WriteAttributeString("Description", Description);

            if (ValueType != null)
            {
                writer.WriteAttributeString("ValueType", ValueType.AssemblyQualifiedName);
            }
        }
    }
}
