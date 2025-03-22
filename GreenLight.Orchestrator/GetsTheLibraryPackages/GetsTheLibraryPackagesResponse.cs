using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheLibraryPackagesResponse
    {
        [JsonProperty("value")]
        public List<Value19> Value { get; set; }
    }

    public class Value19
    {
        [JsonProperty("Created")]
        public string Created { get; set; }

        [JsonProperty("LastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("Owners")]
        public string Owners { get; set; }

        [JsonProperty("IconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("PackageSize")]
        public string PackageSize { get; set; }

        [JsonProperty("IsPrerelease")]
        public string IsPrerelease { get; set; }

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