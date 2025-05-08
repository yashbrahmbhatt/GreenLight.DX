using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class ProjectJSON
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("projectId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectId { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
        public string Main { get; set; }

        [JsonProperty("dependencies", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Dependencies { get; set; }

        [JsonProperty("webServices", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> WebServices { get; set; }

        [JsonProperty("entitiesStores", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> EntitiesStores { get; set; }

        [JsonProperty("schemaVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string SchemaVersion { get; set; }

        [JsonProperty("studioVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string StudioVersion { get; set; }

        [JsonProperty("projectVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectVersion { get; set; }

        [JsonProperty("runtimeOptions", NullValueHandling = NullValueHandling.Ignore)]
        public RuntimeOptions RuntimeOptions { get; set; }

        [JsonProperty("designOptions", NullValueHandling = NullValueHandling.Ignore)]
        public DesignOptions DesignOptions { get; set; }

        [JsonProperty("expressionLanguage", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpressionLanguage { get; set; }

        [JsonProperty("entryPoints", NullValueHandling = NullValueHandling.Ignore)]
        public List<EntryPoint> EntryPoints { get; set; }

        [JsonProperty("isTemplate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTemplate { get; set; }

        [JsonProperty("templateProjectData", NullValueHandling = NullValueHandling.Ignore)]
        public object TemplateProjectData { get; set; }

        [JsonProperty("publishData", NullValueHandling = NullValueHandling.Ignore)]
        public object PublishData { get; set; }

        [JsonProperty("targetFramework", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetFramework { get; set; }
    }
}
