using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsATaskWithTheGivenPrimaryKeyOKResponse
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("AssignedToUser")]
        public AssignedToUser AssignedToUser { get; set; }

        [JsonProperty("TaskAssignmentCriteria")]
        public string TaskAssignmentCriteria { get; set; }

        [JsonProperty("CreatorUser")]
        public AssignedToUser CreatorUser { get; set; }

        [JsonProperty("LastModifierUser")]
        public AssignedToUser LastModifierUser { get; set; }

        [JsonProperty("TaskCatalogName")]
        public string TaskCatalogName { get; set; }

        [JsonProperty("IsCompleted")]
        public string IsCompleted { get; set; }

        [JsonProperty("BulkFormLayoutId")]
        public string BulkFormLayoutId { get; set; }

        [JsonProperty("FormLayoutId")]
        public string FormLayoutId { get; set; }

        [JsonProperty("Encrypted")]
        public string Encrypted { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("Activities")]
        public List<AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsResponse> Activities { get; set; }

        [JsonProperty("TaskSlaDetail")]
        public TaskSlaDetails TaskSlaDetail { get; set; }

        [JsonProperty("TaskAssignments")]
        public List<TaskAssignments> TaskAssignments { get; set; }

        [JsonProperty("TaskAssigneeName")]
        public string TaskAssigneeName { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("AssignedToUserId")]
        public string AssignedToUserId { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("ExternalTag")]
        public string ExternalTag { get; set; }

        [JsonProperty("CreatorJobKey")]
        public string CreatorJobKey { get; set; }

        [JsonProperty("WaitJobKey")]
        public string WaitJobKey { get; set; }

        [JsonProperty("LastAssignedTime")]
        public string LastAssignedTime { get; set; }

        [JsonProperty("CompletionTime")]
        public string CompletionTime { get; set; }

        [JsonProperty("ParentOperationId")]
        public string ParentOperationId { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

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
    }
}