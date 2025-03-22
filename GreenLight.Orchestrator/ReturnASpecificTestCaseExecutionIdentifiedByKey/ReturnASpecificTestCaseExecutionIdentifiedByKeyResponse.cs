using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnASpecificTestCaseExecutionIdentifiedByKeyResponse
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
}