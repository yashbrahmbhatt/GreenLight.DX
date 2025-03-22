using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheProcessesResponse
    {
        [JsonProperty("value")]
        public List<Value29> Value { get; set; }
    }

    public class Value29
    {
        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("Arguments")]
        public Arguments Arguments { get; set; }

        [JsonProperty("SupportsMultipleEntryPoints")]
        public string SupportsMultipleEntryPoints { get; set; }

        [JsonProperty("MainEntryPointPath")]
        public string MainEntryPointPath { get; set; }

        [JsonProperty("RequiresUserInteraction")]
        public string RequiresUserInteraction { get; set; }

        [JsonProperty("RobotVersion")]
        public string RobotVersion { get; set; }

        [JsonProperty("IsAttended")]
        public string IsAttended { get; set; }

        [JsonProperty("TargetFramework")]
        public string TargetFramework { get; set; }

        [JsonProperty("EntryPoints")]
        public List<EntryPoint> EntryPoints { get; set; }

        [JsonProperty("PackageType")]
        public string PackageType { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Published")]
        public string Published { get; set; }

        [JsonProperty("IsLatestVersion")]
        public string IsLatestVersion { get; set; }

        [JsonProperty("OldVersion")]
        public string OldVersion { get; set; }

        [JsonProperty("ReleaseNotes")]
        public string ReleaseNotes { get; set; }

        [JsonProperty("Authors")]
        public string Authors { get; set; }

        [JsonProperty("ProjectType")]
        public string ProjectType { get; set; }

        [JsonProperty("Tags")]
        public string Tags { get; set; }

        [JsonProperty("IsCompiled")]
        public string IsCompiled { get; set; }

        [JsonProperty("LicenseUrl")]
        public string LicenseUrl { get; set; }

        [JsonProperty("ProjectUrl")]
        public string ProjectUrl { get; set; }

        [JsonProperty("ResourceTags")]
        public List<Tags> ResourceTags { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}