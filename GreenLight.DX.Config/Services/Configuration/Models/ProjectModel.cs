using DocumentFormat.OpenXml.Wordprocessing;
using GreenLight.DX.Config.Settings;
using GreenLight.DX.Config.Wizards.Configuration.Misc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UiPath.Studio.Activities.Api;

namespace GreenLight.DX.Config.Services.Configuration.Models
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
        public ObservableCollection<ConfigurationModel> Configurations { get; set; } = new ObservableCollection<ConfigurationModel>() { };

        [XmlIgnore] // Ignore this property during XML serialization
        [JsonIgnore] // Ignore this property during JSON serialization
        public Dictionary<string, IEnumerable<string>> OrchestratorAssets { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        private IWorkflowDesignApi _workflowDesignApi;

        public ProjectModel()
        {
        }
        public ProjectModel(IServiceProvider services)
        {
            InitializeServices(services);
        }

        public void InitializeServices(IServiceProvider services)
        {
            _workflowDesignApi = services.GetRequiredService<IWorkflowDesignApi>();
            _workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationTypesNamespaceKey, out var _namespace);
            Namespace = _namespace ?? _workflowDesignApi.ProjectPropertiesService.GetProjectName() + "." + "Config";
            foreach (ConfigurationModel config in Configurations)
            {
                config.InitializeRowServices(services);
            }
        }

        public string ToNamespaceString()
        {
            List<string> usingStatements = new List<string>();
            foreach (ConfigurationModel config in Configurations)
            {
                var allRows = config.Settings.ToList<ConfigItemModel>().Concat(config.Assets).Concat(config.Resources);
                foreach (ConfigItemModel row in allRows)
                {
                    if (row.ValueType != null && !string.IsNullOrEmpty(row.ValueType.Namespace) && row.ValueType.Namespace != "System" && row.ValueType.Namespace != "System.Collections.Generic")
                    {
                        if (!usingStatements.Contains($"using {row.ValueType.Namespace};"))
                        {
                            usingStatements.Add($"using {row.ValueType.Namespace};");
                        }
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine($"using {typeof(BaseConfig).Namespace};");
            foreach (string usingStatement in usingStatements)
            {
                sb.AppendLine(usingStatement);
            }
            sb.AppendLine();
            sb.AppendLine($"namespace {Namespace}");
            sb.AppendLine("{");
            sb.Append(string.Join("\n", Configurations.Select(c => c.ToClassString(1))));
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
