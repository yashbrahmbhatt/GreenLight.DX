using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GreenLight.DX.Config.Studio.Models
{
    [Serializable]
    [XmlRoot("Configuration")] // Use nameof
    public class ConfigurationModel
    {
        [JsonProperty(nameof(Name))] // Use nameof
        public string Name { get; set; } = "Configuration";

        [JsonProperty(nameof(Description))] // Use nameof
        public string Description { get; set; } = "Description";

        [JsonProperty(nameof(Settings))] // Use nameof
        [XmlArray(nameof(Settings))] // Use nameof
        [XmlArrayItem("Setting")] // Use nameof
        public ObservableCollection<SettingRowModel> Settings { get; set; } = new ObservableCollection<SettingRowModel>() { };

        [JsonProperty(nameof(Assets))] // Use nameof
        [XmlArray(nameof(Assets))] // Use nameof
        [XmlArrayItem("Asset")] // Use nameof
        public ObservableCollection<AssetRowModel> Assets { get; set; } = new ObservableCollection<AssetRowModel>() { };

        [JsonProperty(nameof(Resources))] // Use nameof
        [XmlArray(nameof(Resources))] // Use nameof
        [XmlArrayItem("Resource")] // Use nameof
        public ObservableCollection<ResourceRowModel> Resources { get; set; } = new ObservableCollection<ResourceRowModel>() { };

        public ConfigurationModel()
        {
        }

        public string ToClassString(int indent = 0)
        {
            var indents = new string(' ', indent * 4);
            return
                $"{indents}/// <summary>\n" +
                $"{indents}/// {Description}\n" +
                $"{indents}/// </summary>\n" +
                $"{indents}public class {Name}Config\n" +
                $"{indents}{{\n" +
                $"{indents}{string.Join("", Settings.Select(s => s.ToClassString(indent + 1)))}" +
                $"{indents}{string.Join("", Assets.Select(a => a.ToClassString(indent + 1)))}" +
                $"{indents}{string.Join("", Resources.Select(r => r.ToClassString(indent + 1)))}" +
                $"\n" +
                $"{indents}public {Name}Config() {{ }}\n" +
                $"{indents}}}\n";
        }
    }
}