using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class PecifiedTestCaseExecutionsWithinTheSameTestSetExecutionResponse
    {
        [JsonProperty("JobId")]
        public string JobId { get; set; }

        [JsonProperty("JobKey")]
        public string JobKey { get; set; }

        [JsonProperty("TestSetExecutionId")]
        public string TestSetExecutionId { get; set; }

        [JsonProperty("TestSetExecution")]
        public TestSetExecution TestSetExecution { get; set; }

        [JsonProperty("TestCaseId")]
        public string TestCaseId { get; set; }

        [JsonProperty("TestCase")]
        public TestCase TestCase { get; set; }

        [JsonProperty("ReleaseVersionId")]
        public string ReleaseVersionId { get; set; }

        [JsonProperty("VersionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("EntryPointPath")]
        public string EntryPointPath { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("TestCaseAssertions")]
        public List<TestCaseAssertions> TestCaseAssertions { get; set; }

        [JsonProperty("TestCaseExecutionAttachments")]
        public List<TestCaseExecutionAttachmentsFilteredByIdentifierAndTagsResponse> TestCaseExecutionAttachments { get; set; }

        [JsonProperty("DataVariationIdentifier")]
        public string DataVariationIdentifier { get; set; }

        [JsonProperty("OutputArguments")]
        public string OutputArguments { get; set; }

        [JsonProperty("InputArguments")]
        public string InputArguments { get; set; }

        [JsonProperty("Info")]
        public string Info { get; set; }

        [JsonProperty("HostMachineName")]
        public string HostMachineName { get; set; }

        [JsonProperty("RuntimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("RobotName")]
        public string RobotName { get; set; }

        [JsonProperty("HasAssertions")]
        public string HasAssertions { get; set; }

        [JsonProperty("RunId")]
        public string RunId { get; set; }

        [JsonProperty("TestCaseType")]
        public string TestCaseType { get; set; }

        [JsonProperty("ExecutionOrder")]
        public string ExecutionOrder { get; set; }

        [JsonProperty("TestManagerTestCaseId")]
        public string TestManagerTestCaseId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class TestSet
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Packages")]
        public List<Packages> Packages { get; set; }

        [JsonProperty("TestCases")]
        public List<TestCase> TestCases { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("SourceType")]
        public string SourceType { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("EnvironmentId")]
        public string EnvironmentId { get; set; }

        [JsonProperty("Environment")]
        public Environment Environment { get; set; }

        [JsonProperty("TestCaseCount")]
        public string TestCaseCount { get; set; }

        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("EnableCoverage")]
        public string EnableCoverage { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("InputArguments")]
        public List<InputArguments2> InputArguments { get; set; }

        [JsonProperty("IsDeleted")]
        public string IsDeleted { get; set; }

        [JsonProperty("DeleterUserId")]
        public string DeleterUserId { get; set; }

        [JsonProperty("DeletionTime")]
        public string DeletionTime { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class TestSetExecution
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("TestSetId")]
        public string TestSetId { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("TestSet")]
        public TestSet TestSet { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("TriggerType")]
        public string TriggerType { get; set; }

        [JsonProperty("ScheduleId")]
        public string ScheduleId { get; set; }

        [JsonProperty("BatchExecutionKey")]
        public string BatchExecutionKey { get; set; }

        [JsonProperty("CoverageStatus")]
        public string CoverageStatus { get; set; }

        [JsonProperty("RunId")]
        public string RunId { get; set; }

        [JsonProperty("TestCaseExecutions")]
        public List<TestCaseExecutions2> TestCaseExecutions { get; set; }

        [JsonProperty("Attachments")]
        public List<LTestSetExecutionAttachmentsFilteredByIdentifierAndTagsResponse> Attachments { get; set; }

        [JsonProperty("EnforceExecutionOrder")]
        public string EnforceExecutionOrder { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Definition
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PackageIdentifier")]
        public string PackageIdentifier { get; set; }

        [JsonProperty("UniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("AppVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("CreatedVersion")]
        public string CreatedVersion { get; set; }

        [JsonProperty("LatestVersion")]
        public string LatestVersion { get; set; }

        [JsonProperty("LatestPrereleaseVersion")]
        public string LatestPrereleaseVersion { get; set; }

        [JsonProperty("FeedId")]
        public string FeedId { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class TestCase
    {
        [JsonProperty("DefinitionId")]
        public string DefinitionId { get; set; }

        [JsonProperty("ReleaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("VersionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("Definition")]
        public Definition Definition { get; set; }

        [JsonProperty("TestSetId")]
        public string TestSetId { get; set; }

        [JsonProperty("TestSet")]
        public TestSet TestSet { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Packages
    {
        [JsonProperty("PackageIdentifier")]
        public string PackageIdentifier { get; set; }

        [JsonProperty("VersionMask")]
        public string VersionMask { get; set; }

        [JsonProperty("TestSetId")]
        public string TestSetId { get; set; }

        [JsonProperty("TestSet")]
        public TestSet TestSet { get; set; }

        [JsonProperty("IncludePrerelease")]
        public string IncludePrerelease { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class InputArguments2
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class TestCaseAssertions
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Payload")]
        public string Payload { get; set; }

        [JsonProperty("Succeeded")]
        public string Succeeded { get; set; }

        [JsonProperty("TestCaseExecutionId")]
        public string TestCaseExecutionId { get; set; }

        [JsonProperty("HasScreenshot")]
        public string HasScreenshot { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Environment
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class TestCaseExecutions2
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}