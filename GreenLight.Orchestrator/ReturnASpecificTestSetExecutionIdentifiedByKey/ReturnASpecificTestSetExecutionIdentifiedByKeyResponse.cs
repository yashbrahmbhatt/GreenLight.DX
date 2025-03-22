using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class ReturnASpecificTestSetExecutionIdentifiedByKeyResponse
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
        public List<AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsResponse> TestCaseExecutions { get; set; }

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
}