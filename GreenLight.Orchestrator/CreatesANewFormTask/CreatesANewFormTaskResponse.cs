using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewFormTaskResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("waitJobState")]
        public string WaitJobState { get; set; }

        [JsonProperty("organizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonProperty("tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("assignedToUser")]
        public AssignedToUser AssignedToUser { get; set; }

        [JsonProperty("taskSlaDetails")]
        public List<TaskSlaDetails> TaskSlaDetails { get; set; }

        [JsonProperty("completedByUser")]
        public AssignedToUser CompletedByUser { get; set; }

        [JsonProperty("taskAssignmentCriteria")]
        public string TaskAssignmentCriteria { get; set; }

        [JsonProperty("taskAssignees")]
        public List<AssignedToUser> TaskAssignees { get; set; }

        [JsonProperty("isCurrentUserInAllUserAssignedGroup")]
        public string IsCurrentUserInAllUserAssignedGroup { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("assignedToUserId")]
        public string AssignedToUserId { get; set; }

        [JsonProperty("organizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("externalTag")]
        public string ExternalTag { get; set; }

        [JsonProperty("creatorJobKey")]
        public string CreatorJobKey { get; set; }

        [JsonProperty("waitJobKey")]
        public string WaitJobKey { get; set; }

        [JsonProperty("lastAssignedTime")]
        public string LastAssignedTime { get; set; }

        [JsonProperty("completionTime")]
        public string CompletionTime { get; set; }

        [JsonProperty("parentOperationId")]
        public string ParentOperationId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("isDeleted")]
        public string IsDeleted { get; set; }

        [JsonProperty("deleterUserId")]
        public string DeleterUserId { get; set; }

        [JsonProperty("deletionTime")]
        public string DeletionTime { get; set; }

        [JsonProperty("lastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("lastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("creationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("creatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class AssignedToUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class TaskSlaDetails
    {
        [JsonProperty("expiryTime")]
        public string ExpiryTime { get; set; }

        [JsonProperty("startCriteria")]
        public string StartCriteria { get; set; }

        [JsonProperty("endCriteria")]
        public string EndCriteria { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}