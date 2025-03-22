using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TedProcessingStatusForAGivenQueueInTheLastSpecifiedDaysResponse
    {
        [JsonProperty("value")]
        public List<Value35> Value { get; set; }
    }

    public class Value35
    {
        [JsonProperty("QueueDefinitionId")]
        public string QueueDefinitionId { get; set; }

        [JsonProperty("UiQueueMetadata")]
        public CreatesANewQueueRequest UiQueueMetadata { get; set; }

        [JsonProperty("ProcessingTime")]
        public string ProcessingTime { get; set; }

        [JsonProperty("ReportType")]
        public string ReportType { get; set; }

        [JsonProperty("NumberOfRemainingTransactions")]
        public string NumberOfRemainingTransactions { get; set; }

        [JsonProperty("NumberOfInProgressTransactions")]
        public string NumberOfInProgressTransactions { get; set; }

        [JsonProperty("NumberOfApplicationExceptions")]
        public string NumberOfApplicationExceptions { get; set; }

        [JsonProperty("NumberOfBusinessExceptions")]
        public string NumberOfBusinessExceptions { get; set; }

        [JsonProperty("NumberOfSuccessfulTransactions")]
        public string NumberOfSuccessfulTransactions { get; set; }

        [JsonProperty("NumberOfRetriedItems")]
        public string NumberOfRetriedItems { get; set; }

        [JsonProperty("ApplicationExceptionsProcessingTime")]
        public string ApplicationExceptionsProcessingTime { get; set; }

        [JsonProperty("BusinessExceptionsProcessingTime")]
        public string BusinessExceptionsProcessingTime { get; set; }

        [JsonProperty("SuccessfulTransactionsProcessingTime")]
        public string SuccessfulTransactionsProcessingTime { get; set; }

        [JsonProperty("TotalNumberOfTransactions")]
        public string TotalNumberOfTransactions { get; set; }

        [JsonProperty("TenantId")]
        public string TenantId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}