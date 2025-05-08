using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Project.Models
{
    public class RuntimeOptions
    {
        [JsonProperty("autoDispose", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoDispose { get; set; }

        [JsonProperty("netFrameworkLazyLoading", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NetFrameworkLazyLoading { get; set; }

        [JsonProperty("isPausable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPausable { get; set; }

        [JsonProperty("isAttended", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAttended { get; set; }

        [JsonProperty("requiresUserInteraction", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequiresUserInteraction { get; set; }

        [JsonProperty("supportsPersistence", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SupportsPersistence { get; set; }

        [JsonProperty("workflowSerialization", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowSerialization { get; set; }

        [JsonProperty("excludedLoggedData", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludedLoggedData { get; set; }

        [JsonProperty("executionType", NullValueHandling = NullValueHandling.Ignore)]
        public string ExecutionType { get; set; }

        [JsonProperty("readyForPiP", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReadyForPiP { get; set; }

        [JsonProperty("startsInPiP", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StartsInPiP { get; set; }

        [JsonProperty("mustRestoreAllDependencies", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MustRestoreAllDependencies { get; set; }

        [JsonProperty("pipType", NullValueHandling = NullValueHandling.Ignore)]
        public string PipType { get; set; }
    }
}
