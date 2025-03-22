using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnsTheLastRetryOfAQueueItemByUniqueKeyOKResponse
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

    public class SpecificContent2
    {
        [JsonProperty("eiusmod_1d")]
        public Eiusmod1d Eiusmod1d { get; set; }

        [JsonProperty("fugiat2")]
        public Fugiat2 Fugiat2 { get; set; }

        [JsonProperty("in_0f")]
        public In0f In0f { get; set; }

        [JsonProperty("sint_b")]
        public SintB SintB { get; set; }
    }

    public class Analytics2
    {
        [JsonProperty("sint_7b")]
        public Sint7b Sint7b { get; set; }

        [JsonProperty("aliqua_f2")]
        public AliquaF2 AliquaF2 { get; set; }
    }

    public class Output2
    {
        [JsonProperty("ullamco_d")]
        public UllamcoD UllamcoD { get; set; }

        [JsonProperty("ea31d")]
        public Ea31d Ea31d { get; set; }
    }

    public class AliquaF2
    {
    }

    public class Amet1
    {
    }

    public class Dolor79
    {
    }

    public class Ea31d
    {
    }

    public class Eiusmod1d
    {
    }

    public class Fugiat2
    {
    }

    public class In0f
    {
    }

    public class IpsumB12
    {
    }

    public class LaboreE
    {
    }

    public class Laboris86
    {
    }

    public class Nulla7
    {
    }

    public class Sint7b
    {
    }

    public class SintB
    {
    }

    public class UllamcoD
    {
    }

    public class VelitFde
    {
    }
}