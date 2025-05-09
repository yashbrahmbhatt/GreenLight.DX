using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using System;
using Newtonsoft.Json;

namespace GreenLight.DX.Config.Services.Configuration.Models
{
    [Serializable]
    [XmlRoot("Configuration")] // Use nameof
    public class ConfigurationModel
    {
        [JsonProperty(nameof(Id))] // Use nameof
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty(nameof(Name))] // Use nameof
        public string Name { get; set; } = "Configuration";

        [JsonProperty(nameof(Description))] // Use nameof
        public string Description { get; set; } = "Description";

        [JsonProperty(nameof(Settings))] // Use nameof
        [XmlArray(nameof(Settings))] // Use nameof
        [XmlArrayItem("Setting")] // Use nameof
        public ObservableCollection<SettingItemModel> Settings { get; set; } = new ObservableCollection<SettingItemModel>() { };

        [JsonProperty(nameof(Assets))] // Use nameof
        [XmlArray(nameof(Assets))] // Use nameof
        [XmlArrayItem("Asset")] // Use nameof
        public ObservableCollection<AssetItemModel> Assets { get; set; } = new ObservableCollection<AssetItemModel>() { };

        [JsonProperty(nameof(Resources))] // Use nameof
        [XmlArray(nameof(Resources))] // Use nameof
        [XmlArrayItem("Resource")] // Use nameof
        public ObservableCollection<ResourceItemModel> Resources { get; set; } = new ObservableCollection<ResourceItemModel>() { };

        public ConfigurationModel()
        {
        }
        public ConfigurationModel(IServiceProvider services)
        {
            InitializeRowServices(services);
        }

        public void InitializeRowServices(IServiceProvider services)
        {
            foreach (var setting in Settings) setting.InitializeServices(services);
            foreach (var asset in Assets) asset.InitializeServices(services);
            foreach (var resource in Resources) resource.InitializeServices(services);
        }

        public string ToClassString(int indent = 0)
        {
            var indents = new string(' ', indent * 4);
            var description = string.IsNullOrWhiteSpace(Description) ? "No description" : Description;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{indents}/// <summary>");
            sb.AppendLine($"{indents}/// {description}");
            sb.AppendLine($"{indents}/// </summary>");
            sb.AppendLine($"{indents}public class {Helpers.Strings.ToValidIdentifier(Name)}Config : BaseConfig");
            sb.AppendLine($"{indents}{{");
            foreach (var setting in Settings) sb.Append(setting.ToClassString(indent + 1));
            foreach (var asset in Assets) sb.Append(asset.ToClassString(indent + 1));
            foreach (var resource in Resources) sb.Append(resource.ToClassString(indent + 1));
            sb.AppendLine();
            sb.AppendLine($"{new string(' ', (indent + 1) * 4)}public {Helpers.Strings.ToValidIdentifier(Name)}Config() {{ }}");
            sb.AppendLine($"{indents}}}");
            return sb.ToString();
        }
    }
}
