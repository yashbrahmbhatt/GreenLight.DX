using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AssignsTheTasksToGivenUsersRequest
    {
        [JsonProperty("taskAssignments")]
        public List<TaskAssignments2> TaskAssignments { get; set; }
    }

    public class TaskAssignments2
    {
        [JsonProperty("TaskId")]
        public string TaskId { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("UserNameOrEmail")]
        public string UserNameOrEmail { get; set; }

        [JsonProperty("AssignmentCriteria")]
        public string AssignmentCriteria { get; set; }

        [JsonProperty("AssigneeNamesOrEmails")]
        public List<string> AssigneeNamesOrEmails { get; set; }

        [JsonProperty("AssigneeUserIds")]
        public List<string> AssigneeUserIds { get; set; }
    }
}