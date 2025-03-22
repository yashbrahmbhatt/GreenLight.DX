using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetAllVersionsOfTaskDefinitionOKResponse
    {
        [JsonProperty("TaskDefinitionName")]
        public string TaskDefinitionName { get; set; }

        [JsonProperty("TaskDefintionCurrentVersion")]
        public string TaskDefintionCurrentVersion { get; set; }

        [JsonProperty("TaskDefintionCreationDate")]
        public string TaskDefintionCreationDate { get; set; }

        [JsonProperty("TaskDefintionUpdationTime")]
        public string TaskDefintionUpdationTime { get; set; }

        [JsonProperty("TaskDefintionVersions")]
        public List<TaskDefintionVersions> TaskDefintionVersions { get; set; }
    }

    public class TaskDefintionVersions
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("creationDate")]
        public string CreationDate { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}