using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsEnvironmentsResponse
    {
        [JsonProperty("value")]
        public List<Value10> Value { get; set; }
    }

    public class Robots
    {
        [JsonProperty("HostingType")]
        public string HostingType { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("LicenseKey")]
        public string LicenseKey { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("ExternalName")]
        public string ExternalName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ProvisionType")]
        public string ProvisionType { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("CredentialType")]
        public string CredentialType { get; set; }

        [JsonProperty("Environments")]
        public List<AsReadAndReturnsTheRemainingNumberOfUnreadNotificationsResponse> Environments { get; set; }

        [JsonProperty("RobotEnvironments")]
        public string RobotEnvironments { get; set; }

        [JsonProperty("ExecutionSettings")]
        public ExecutionSettings ExecutionSettings { get; set; }

        [JsonProperty("IsExternalLicensed")]
        public string IsExternalLicensed { get; set; }

        [JsonProperty("LimitConcurrentExecution")]
        public string LimitConcurrentExecution { get; set; }

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

    public class ExecutionSettings
    {
        [JsonProperty("magna_f77")]
        public MagnaF77 MagnaF77 { get; set; }

        [JsonProperty("deserunt53")]
        public Deserunt53 Deserunt53 { get; set; }

        [JsonProperty("mollit__")]
        public Mollit Mollit { get; set; }

        [JsonProperty("exercitation_f5_")]
        public ExercitationF5 ExercitationF5 { get; set; }

        [JsonProperty("elit5cc")]
        public Elit5cc Elit5cc { get; set; }

        [JsonProperty("ut6")]
        public Ut6 Ut6 { get; set; }

        [JsonProperty("tempor98")]
        public Tempor98 Tempor98 { get; set; }

        [JsonProperty("adipisicing3d")]
        public Adipisicing3d Adipisicing3d { get; set; }

        [JsonProperty("esse8f3")]
        public Esse8f3 Esse8f3 { get; set; }

        [JsonProperty("culpa_75")]
        public Culpa75 Culpa75 { get; set; }

        [JsonProperty("ullamco_17")]
        public Ullamco17 Ullamco17 { get; set; }

        [JsonProperty("sunt_f")]
        public SuntF SuntF { get; set; }
    }

    public class Value10
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Robots")]
        public List<Robots> Robots { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class Adipisicing3d
    {
    }

    public class Culpa75
    {
    }

    public class Deserunt53
    {
    }

    public class Elit5cc
    {
    }

    public class Esse8f3
    {
    }

    public class ExercitationF5
    {
    }

    public class MagnaF77
    {
    }

    public class Mollit
    {
    }

    public class SuntF
    {
    }

    public class Tempor98
    {
    }

    public class Ullamco17
    {
    }

    public class Ut6
    {
    }
}