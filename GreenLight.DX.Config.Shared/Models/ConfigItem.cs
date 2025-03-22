using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using GreenLight.DX.Config.Shared.Serializers;
using System.Text;
using UiPath.Studio.Activities.Api;
using Microsoft.Extensions.DependencyInjection;
using GreenLight.DX.Config.Studio.Services;
using System.ComponentModel; // Assuming TypeSerializer is here

namespace GreenLight.DX.Config.Shared.Models
{
    [Serializable]
    [XmlInclude(typeof(SettingItem))]
    [XmlInclude(typeof(AssetItem))]
    [XmlInclude(typeof(ResourceItem))]
    public abstract class ConfigItem : IXmlSerializable
    {
        [XmlIgnore]
        [JsonIgnore]
        public ITypeParserService _typeParserService;


        [JsonProperty(nameof(Key))]
        public string Key { get; set; } = "Key";

        [JsonProperty(nameof(Description))]
        public string Description { get; set; } = "Description";

        [XmlIgnore]
        [JsonConverter(typeof(TypeSerializer))] // Your custom JSON converter
        public Type ValueType { get; set; } = typeof(string);

        [XmlIgnore]
        [JsonIgnore]
        public abstract object? Value { get; set; }

        public ConfigItem()
        {
        }
        public ConfigItem(IServiceProvider services) : this()
        {
            InitializeServices(services);
        }

        public virtual void InitializeServices(IServiceProvider provider)
        {

            _typeParserService = provider.GetRequiredService<ITypeParserService>();
        }

        public string ToClassString(int indent = 0)
        {
            var indents = new string(' ', indent * 4);
            string typeName = ValueType?.Name ?? "object"; // Handle null ValueType

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
        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            Key = reader.GetAttribute("Key");
            Description = reader.GetAttribute("Description");

            string typeName = reader.GetAttribute("ValueType");
            if (!string.IsNullOrEmpty(typeName))
            {
                ValueType = Type.GetType(typeName);
            }

            // Read the value based on ValueType
            if (ValueType != null && !reader.IsEmptyElement)
            {
                reader.ReadStartElement("Value"); // Read Value element
                string valueString = reader.ReadContentAsString();
                reader.ReadEndElement(); // End Value element
            }

            reader.ReadEndElement();
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