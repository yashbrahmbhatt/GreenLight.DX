using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsAQueueItemByIdResponse
    {
        [JsonProperty("QueueDefinitionId")]
        public string QueueDefinitionId { get; set; }

        [JsonProperty("QueueDefinition")]
        public CreatesANewQueueRequest QueueDefinition { get; set; }

        [JsonProperty("ProcessingException")]
        public ProcessingException ProcessingException { get; set; }

        [JsonProperty("Encrypted")]
        public string Encrypted { get; set; }

        [JsonProperty("SpecificContent")]
        public SpecificContent2 SpecificContent { get; set; }

        [JsonProperty("Output")]
        public Output2 Output { get; set; }

        [JsonProperty("OutputData")]
        public string OutputData { get; set; }

        [JsonProperty("Analytics")]
        public Analytics2 Analytics { get; set; }

        [JsonProperty("AnalyticsData")]
        public string AnalyticsData { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("ReviewStatus")]
        public string ReviewStatus { get; set; }

        [JsonProperty("ReviewerUserId")]
        public string ReviewerUserId { get; set; }

        [JsonProperty("ReviewerUser")]
        public Value26 ReviewerUser { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("ProcessingExceptionType")]
        public string ProcessingExceptionType { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("RiskSlaDate")]
        public string RiskSlaDate { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Robot")]
        public Robots Robot { get; set; }

        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("CreatorJobKey")]
        public string CreatorJobKey { get; set; }

        [JsonProperty("ExecutorJobKey")]
        public string ExecutorJobKey { get; set; }

        [JsonProperty("DeferDate")]
        public string DeferDate { get; set; }

        [JsonProperty("StartProcessing")]
        public string StartProcessing { get; set; }

        [JsonProperty("EndProcessing")]
        public string EndProcessing { get; set; }

        [JsonProperty("SecondsInPreviousAttempts")]
        public string SecondsInPreviousAttempts { get; set; }

        [JsonProperty("AncestorId")]
        public string AncestorId { get; set; }

        [JsonProperty("AncestorUniqueKey")]
        public string AncestorUniqueKey { get; set; }

        [JsonProperty("RetryNumber")]
        public string RetryNumber { get; set; }

        [JsonProperty("ManualAncestorId")]
        public string ManualAncestorId { get; set; }

        [JsonProperty("ManualAncestorUniqueKey")]
        public string ManualAncestorUniqueKey { get; set; }

        [JsonProperty("ManualRetryNumber")]
        public string ManualRetryNumber { get; set; }

        [JsonProperty("UniqueKey")]
        public string UniqueKey { get; set; }

        [JsonProperty("HasVideoRecorded")]
        public string HasVideoRecorded { get; set; }

        [JsonProperty("SpecificData")]
        public string SpecificData { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Progress")]
        public string Progress { get; set; }

        [JsonProperty("RowVersion")]
        public string RowVersion { get; set; }

        [JsonProperty("ParentOperationId")]
        public string ParentOperationId { get; set; }

        [JsonProperty("OperationId")]
        public string OperationId { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("OrganizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}