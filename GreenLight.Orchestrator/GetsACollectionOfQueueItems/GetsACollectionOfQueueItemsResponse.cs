using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsACollectionOfQueueItemsResponse
    {
        [JsonProperty("value")]
        public List<Value34> Value { get; set; }
    }

    public class Value34
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
        public SpecificContent SpecificContent { get; set; }

        [JsonProperty("Output")]
        public Output Output { get; set; }

        [JsonProperty("OutputData")]
        public string OutputData { get; set; }

        [JsonProperty("Analytics")]
        public Analytics Analytics { get; set; }

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

    public class Analytics
    {
        [JsonProperty("est85")]
        public Est85 Est85 { get; set; }

        [JsonProperty("anim2")]
        public Anim2 Anim2 { get; set; }

        [JsonProperty("sunt_a6")]
        public SuntA6 SuntA6 { get; set; }

        [JsonProperty("id_c3")]
        public IdC3 IdC3 { get; set; }

        [JsonProperty("Utca")]
        public Utca Utca { get; set; }

        [JsonProperty("adipisicing_7b")]
        public Adipisicing7b Adipisicing7b { get; set; }
    }

    public class ProcessingException
    {
        [JsonProperty("Reason")]
        public string Reason { get; set; }

        [JsonProperty("Details")]
        public string Details { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("AssociatedImageFilePath")]
        public string AssociatedImageFilePath { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }
    }

    public class SpecificContent
    {
        [JsonProperty("utb8")]
        public Utb8 Utb8 { get; set; }

        [JsonProperty("quis_789")]
        public Quis789 Quis789 { get; set; }

        [JsonProperty("nostrudf")]
        public Nostrudf Nostrudf { get; set; }

        [JsonProperty("minim_6")]
        public Minim6 Minim6 { get; set; }

        [JsonProperty("consequat_04e")]
        public Consequat04e Consequat04e { get; set; }
    }

    public class Output
    {
        [JsonProperty("ad3")]
        public Ad3 Ad3 { get; set; }

        [JsonProperty("ex_e")]
        public ExE ExE { get; set; }

        [JsonProperty("mollit_34")]
        public Mollit34 Mollit34 { get; set; }

        [JsonProperty("minim_f92")]
        public MinimF92 MinimF92 { get; set; }
    }

    public class Ad3
    {
    }

    public class Adipisicing7b
    {
    }

    public class Aliqua3
    {
    }

    public class Anim2
    {
    }

    public class Consequat04e
    {
    }

    public class Consequat1
    {
    }

    public class Esse0
    {
    }

    public class Est85
    {
    }

    public class ExE
    {
    }

    public class ExcepteurE66
    {
    }

    public class IdC3
    {
    }

    public class Laborisd
    {
    }

    public class Minim6
    {
    }

    public class MinimF92
    {
    }

    public class Mollit34
    {
    }

    public class Nostrudf
    {
    }

    public class QuiE
    {
    }

    public class Quis789
    {
    }

    public class SuntA6
    {
    }

    public class UtC7
    {
    }

    public class Uta8
    {
    }

    public class Utb8
    {
    }

    public class Utca
    {
    }

    public class VeniamB1
    {
    }
}