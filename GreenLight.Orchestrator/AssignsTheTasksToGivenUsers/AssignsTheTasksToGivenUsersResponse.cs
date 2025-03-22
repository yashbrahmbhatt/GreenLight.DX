using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AssignsTheTasksToGivenUsersResponse
    {
        [JsonProperty("value")]
        public List<Value53> Value { get; set; }
    }

    public class Value53
    {
        [JsonProperty("TaskId")]
        public string TaskId { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("ErrorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("UserNameOrEmail")]
        public string UserNameOrEmail { get; set; }
    }
}