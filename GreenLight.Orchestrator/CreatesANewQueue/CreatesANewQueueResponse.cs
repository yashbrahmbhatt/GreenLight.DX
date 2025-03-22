using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewQueueResponse
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("MaxNumberOfRetries")]
        public string MaxNumberOfRetries { get; set; }

        [JsonProperty("AcceptAutomaticallyRetry")]
        public string AcceptAutomaticallyRetry { get; set; }

        [JsonProperty("RetryAbandonedItems")]
        public string RetryAbandonedItems { get; set; }

        [JsonProperty("EnforceUniqueReference")]
        public string EnforceUniqueReference { get; set; }

        [JsonProperty("Encrypted")]
        public string Encrypted { get; set; }

        [JsonProperty("SpecificDataJsonSchema")]
        public string SpecificDataJsonSchema { get; set; }

        [JsonProperty("OutputDataJsonSchema")]
        public string OutputDataJsonSchema { get; set; }

        [JsonProperty("AnalyticsDataJsonSchema")]
        public string AnalyticsDataJsonSchema { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("ProcessScheduleId")]
        public string ProcessScheduleId { get; set; }

        [JsonProperty("SlaInMinutes")]
        public string SlaInMinutes { get; set; }

        [JsonProperty("RiskSlaInMinutes")]
        public string RiskSlaInMinutes { get; set; }

        [JsonProperty("ReleaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("IsProcessInCurrentFolder")]
        public string IsProcessInCurrentFolder { get; set; }

        [JsonProperty("FoldersCount")]
        public string FoldersCount { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("OrganizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}