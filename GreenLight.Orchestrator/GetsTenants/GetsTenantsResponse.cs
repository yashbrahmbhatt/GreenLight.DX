using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTenantsResponse
    {
        [JsonProperty("value")]
        public List<Value54> Value { get; set; }
    }

    public class Value54
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("AdminEmailAddress")]
        public string AdminEmailAddress { get; set; }

        [JsonProperty("AdminName")]
        public string AdminName { get; set; }

        [JsonProperty("AdminSurname")]
        public string AdminSurname { get; set; }

        [JsonProperty("AdminUserKey")]
        public string AdminUserKey { get; set; }

        [JsonProperty("AdminPassword")]
        public string AdminPassword { get; set; }

        [JsonProperty("LastLoginTime")]
        public string LastLoginTime { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("License")]
        public License2 License { get; set; }

        [JsonProperty("OrganizationName")]
        public string OrganizationName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class License2
    {
        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Allowed")]
        public Allowed2 Allowed { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Allowed2
    {
        [JsonProperty("aliquip__05")]
        public string Aliquip05 { get; set; }

        [JsonProperty("enimc4")]
        public string Enimc4 { get; set; }

        [JsonProperty("doe")]
        public string Doe { get; set; }
    }
}