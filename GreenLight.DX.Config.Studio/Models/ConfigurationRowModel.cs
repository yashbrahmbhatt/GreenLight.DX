using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using GreenLight.DX.Config.Studio.Converters;
using GreenLight.DX.Config.Studio.Models;
using System.Runtime.Serialization; // Assuming your TypeSerializer is here

namespace GreenLight.DX.Config.Studio.Models
{


    [Serializable]
    [XmlInclude(typeof(SettingRowModel))]
    [XmlInclude(typeof(AssetRowModel))]
    [XmlInclude(typeof(ResourceRowModel))]
    public abstract class ConfigurationRowModel : IXmlSerializable
    {
        [JsonProperty(nameof(Key))]
        public string Key { get; set; } = "Key";

        [JsonProperty(nameof(Description))]
        public string Description { get; set; } = "Description";

        [XmlIgnore]
        [JsonConverter(typeof(TypeSerializer))] // Your custom JSON converter

        public Type SelectedType { get; set; } = typeof(string);

        public string ToClassString(int indent = 0)
        {
            var indents = new string(' ', indent * 4);
            return
                $"{indents}/// <summary>\n" +
                $"{indents}/// {Description}\n" +
                $"{indents}/// </summary>\n" +
                $"{indents}public {SelectedType?.Name ?? "object"} {Key} {{ get; set; }}\n\n";
        }

        // IXmlSerializable Implementation
        public XmlSchema GetSchema() => null; // Not used

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement(); // Move past the element start tag

            Key = reader.GetAttribute("Key");
            Description = reader.GetAttribute("Description");

            string typeName = reader.GetAttribute("SelectedType");
            if (!string.IsNullOrEmpty(typeName))
            {
                SelectedType = Type.GetType(typeName); // Robust Type.GetType() recommended
            }

            reader.ReadEndElement(); // Move past the element end tag
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Key", Key);
            writer.WriteAttributeString("Description", Description);

            if (SelectedType != null)
            {
                writer.WriteAttributeString("SelectedType", SelectedType.AssemblyQualifiedName);
            }
        }
    }
}