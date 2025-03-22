using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class RetrievesTheCurrentLicenseInformationResponse
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("ExpireDate")]
        public string ExpireDate { get; set; }

        [JsonProperty("GracePeriodEndDate")]
        public string GracePeriodEndDate { get; set; }

        [JsonProperty("GracePeriod")]
        public string GracePeriod { get; set; }

        [JsonProperty("VersionControl")]
        public string VersionControl { get; set; }

        [JsonProperty("Allowed")]
        public Allowed Allowed { get; set; }

        [JsonProperty("Used")]
        public Used Used { get; set; }

        [JsonProperty("AttendedConcurrent")]
        public string AttendedConcurrent { get; set; }

        [JsonProperty("DevelopmentConcurrent")]
        public string DevelopmentConcurrent { get; set; }

        [JsonProperty("StudioXConcurrent")]
        public string StudioXConcurrent { get; set; }

        [JsonProperty("StudioProConcurrent")]
        public string StudioProConcurrent { get; set; }

        [JsonProperty("LicensedFeatures")]
        public List<string> LicensedFeatures { get; set; }

        [JsonProperty("IsRegistered")]
        public string IsRegistered { get; set; }

        [JsonProperty("IsCommunity")]
        public string IsCommunity { get; set; }

        [JsonProperty("IsProOrEnterprise")]
        public string IsProOrEnterprise { get; set; }

        [JsonProperty("SubscriptionCode")]
        public string SubscriptionCode { get; set; }

        [JsonProperty("SubscriptionPlan")]
        public string SubscriptionPlan { get; set; }

        [JsonProperty("IsExpired")]
        public string IsExpired { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("UserLicensingEnabled")]
        public string UserLicensingEnabled { get; set; }
    }

    public class Used
    {
        [JsonProperty("aliquip_da")]
        public string AliquipDa { get; set; }

        [JsonProperty("pariatur_8")]
        public string Pariatur8 { get; set; }
    }

    public class Allowed
    {
        [JsonProperty("fugiat_0d")]
        public string Fugiat0d { get; set; }
    }
}