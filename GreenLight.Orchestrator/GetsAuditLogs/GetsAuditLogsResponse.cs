using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsAuditLogsResponse
    {
        [JsonProperty("value")]
        public List<Value3> Value { get; set; }
    }

    public class Value3
    {
        [JsonProperty("ServiceName")]
        public string ServiceName { get; set; }

        [JsonProperty("MethodName")]
        public string MethodName { get; set; }

        [JsonProperty("Parameters")]
        public string Parameters { get; set; }

        [JsonProperty("ExecutionTime")]
        public string ExecutionTime { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("Component")]
        public string Component { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("EntityId")]
        public string EntityId { get; set; }

        [JsonProperty("OperationText")]
        public string OperationText { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }

        [JsonProperty("Entities")]
        public List<Entities> Entities { get; set; }

        [JsonProperty("ExternalClientId")]
        public string ExternalClientId { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("UserIsDeleted")]
        public string UserIsDeleted { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Entities
    {
        [JsonProperty("AuditLogId")]
        public string AuditLogId { get; set; }

        [JsonProperty("CustomData")]
        public string CustomData { get; set; }

        [JsonProperty("EntityId")]
        public string EntityId { get; set; }

        [JsonProperty("EntityName")]
        public string EntityName { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}