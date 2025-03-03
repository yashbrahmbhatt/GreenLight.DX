
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Studio.Models
{
    [Serializable] // Mark the class as serializable
    [XmlRoot("Project")] // Optional: Specify the root XML element name
    public class ProjectModel
    {
        [JsonProperty(nameof(Namespace))] // Optional: Specify JSON property name
        public string Namespace { get; set; } = "MyNamespace";

        [JsonProperty(nameof(Configurations))] // Optional: Specify JSON property name
        [XmlArray(nameof(Configurations))] // Optional: Specify XML array name
        [XmlArrayItem("Configuration")] // Optional: Specify XML item name
        public ObservableCollection<ConfigurationModel> Configurations { get; set; } = new ObservableCollection<ConfigurationModel>() { new ConfigurationModel() };

        [XmlIgnore] // Ignore this property during XML serialization
        [JsonIgnore] // Ignore this property during JSON serialization
        public Dictionary<string, IEnumerable<string>> OrchestratorAssets { get; set; }

        public ProjectModel()
        {
        }
        public ProjectModel(string name)
        {
            Namespace = name;
        }

        public string ToClassString(ConfigurationModel configuration)
        {
            return
                $"using System;\n" +
                $"using System.Collections.Generic;\n" +
                $"using System.Linq;\n" +
                $"using System.Text;\n" +
                $"using System.Data;\n" +
                $"using Newtonsoft.Json\n" +
                $"\n" +
                $"namespace {Namespace}\n" +
                $"{{\n" +
                $"{configuration.ToClassString(1)}" +
                $"}}\n";
        }
    }
}
