using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTaskDefinitionObjectsWithTheGivenODataQueriesResponse
    {
        [JsonProperty("value")]
        public List<Value50> Value { get; set; }
    }

    public class Value50
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Properties")]
        public Properties Properties { get; set; }

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

    public class Properties
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("allowedActions")]
        public List<string> AllowedActions { get; set; }

        [JsonProperty("allowedActionsForDefinition")]
        public string AllowedActionsForDefinition { get; set; }

        [JsonProperty("taskDefinitionKey")]
        public string TaskDefinitionKey { get; set; }

        [JsonProperty("creationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("creatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("creatorUserKey")]
        public string CreatorUserKey { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}