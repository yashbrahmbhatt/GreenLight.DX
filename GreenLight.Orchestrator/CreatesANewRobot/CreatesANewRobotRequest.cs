using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewRobotRequest
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
        public List<Environments> Environments { get; set; }

        [JsonProperty("RobotEnvironments")]
        public string RobotEnvironments { get; set; }

        [JsonProperty("ExecutionSettings")]
        public ExecutionSettings3 ExecutionSettings { get; set; }

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

    public class ExecutionSettings3
    {
        [JsonProperty("aliquip_a")]
        public AliquipA AliquipA { get; set; }

        [JsonProperty("Duis7")]
        public Duis7 Duis7 { get; set; }

        [JsonProperty("in_d5")]
        public InD5 InD5 { get; set; }

        [JsonProperty("idf_a")]
        public IdfA IdfA { get; set; }

        [JsonProperty("nostrud_b2")]
        public NostrudB2 NostrudB2 { get; set; }

        [JsonProperty("do_558")]
        public Do558 Do558 { get; set; }

        [JsonProperty("aute78a")]
        public Aute78a Aute78a { get; set; }

        [JsonProperty("labore_6f8")]
        public Labore6f8 Labore6f8 { get; set; }

        [JsonProperty("dolor62d")]
        public Dolor62d Dolor62d { get; set; }

        [JsonProperty("amet0")]
        public Amet0 Amet0 { get; set; }
    }

    public class Environments
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Robots")]
        public List<CreatesANewRobotRequest> Robots { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class AliquipA
    {
    }

    public class Amet0
    {
    }

    public class Aute78a
    {
    }

    public class Do558
    {
    }

    public class Dolor62d
    {
    }

    public class Duis7
    {
    }

    public class IdfA
    {
    }

    public class InD5
    {
    }

    public class Labore6f8
    {
    }

    public class NostrudB2
    {
    }
}