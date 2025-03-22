using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AddsATaskNoteResponse
    {
        [JsonProperty("CreatorUser")]
        public AssignedToUser CreatorUser { get; set; }

        [JsonProperty("LastModifierUser")]
        public AssignedToUser LastModifierUser { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("TenantId")]
        public string TenantId { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("TaskId")]
        public string TaskId { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}