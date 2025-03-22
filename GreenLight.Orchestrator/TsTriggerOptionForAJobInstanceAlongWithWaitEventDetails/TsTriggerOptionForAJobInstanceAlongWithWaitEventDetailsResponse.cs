using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class TsTriggerOptionForAJobInstanceAlongWithWaitEventDetailsResponse
    {
        [JsonProperty("value")]
        public List<Value18> Value { get; set; }
    }

    public class Value18
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("JobId")]
        public string JobId { get; set; }

        [JsonProperty("TriggerType")]
        public string TriggerType { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("ItemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("ItemId")]
        public string ItemId { get; set; }

        [JsonProperty("Timer")]
        public string Timer { get; set; }

        [JsonProperty("TriggerMessage")]
        public string TriggerMessage { get; set; }

        [JsonProperty("ItemName")]
        public string ItemName { get; set; }

        [JsonProperty("AssignedToUserId")]
        public string AssignedToUserId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("ModifiedTime")]
        public string ModifiedTime { get; set; }
    }
}