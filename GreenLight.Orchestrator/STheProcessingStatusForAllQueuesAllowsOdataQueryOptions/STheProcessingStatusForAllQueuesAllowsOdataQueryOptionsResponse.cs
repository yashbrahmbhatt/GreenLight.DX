using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class STheProcessingStatusForAllQueuesAllowsOdataQueryOptionsResponse
    {
        [JsonProperty("value")]
        public List<Value36> Value { get; set; }
    }

    public class Value36
    {
        [JsonProperty("ItemsToProcess")]
        public string ItemsToProcess { get; set; }

        [JsonProperty("ItemsInProgress")]
        public string ItemsInProgress { get; set; }

        [JsonProperty("QueueDefinitionId")]
        public string QueueDefinitionId { get; set; }

        [JsonProperty("QueueDefinitionKey")]
        public string QueueDefinitionKey { get; set; }

        [JsonProperty("QueueDefinitionName")]
        public string QueueDefinitionName { get; set; }

        [JsonProperty("QueueDefinitionDescription")]
        public string QueueDefinitionDescription { get; set; }

        [JsonProperty("QueueDefinitionAcceptAutomaticallyRetry")]
        public string QueueDefinitionAcceptAutomaticallyRetry { get; set; }

        [JsonProperty("QueueDefinitionRetryAbandonedItems")]
        public string QueueDefinitionRetryAbandonedItems { get; set; }

        [JsonProperty("QueueDefinitionMaxNumberOfRetries")]
        public string QueueDefinitionMaxNumberOfRetries { get; set; }

        [JsonProperty("QueueDefinitionEnforceUniqueReference")]
        public string QueueDefinitionEnforceUniqueReference { get; set; }

        [JsonProperty("ProcessingMeanTime")]
        public string ProcessingMeanTime { get; set; }

        [JsonProperty("SuccessfulTransactionsNo")]
        public string SuccessfulTransactionsNo { get; set; }

        [JsonProperty("ApplicationExceptionsNo")]
        public string ApplicationExceptionsNo { get; set; }

        [JsonProperty("BusinessExceptionsNo")]
        public string BusinessExceptionsNo { get; set; }

        [JsonProperty("SuccessfulTransactionsProcessingTime")]
        public string SuccessfulTransactionsProcessingTime { get; set; }

        [JsonProperty("ApplicationExceptionsProcessingTime")]
        public string ApplicationExceptionsProcessingTime { get; set; }

        [JsonProperty("BusinessExceptionsProcessingTime")]
        public string BusinessExceptionsProcessingTime { get; set; }

        [JsonProperty("TotalNumberOfTransactions")]
        public string TotalNumberOfTransactions { get; set; }

        [JsonProperty("LastProcessed")]
        public string LastProcessed { get; set; }

        [JsonProperty("ReleaseName")]
        public string ReleaseName { get; set; }

        [JsonProperty("ReleaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("IsProcessInCurrentFolder")]
        public string IsProcessInCurrentFolder { get; set; }

        [JsonProperty("SpecificDataJsonSchemaExists")]
        public string SpecificDataJsonSchemaExists { get; set; }

        [JsonProperty("OutputDataJsonSchemaExists")]
        public string OutputDataJsonSchemaExists { get; set; }

        [JsonProperty("AnalyticsDataJsonSchemaExists")]
        public string AnalyticsDataJsonSchemaExists { get; set; }

        [JsonProperty("ProcessScheduleId")]
        public string ProcessScheduleId { get; set; }

        [JsonProperty("QueueFoldersCount")]
        public string QueueFoldersCount { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}