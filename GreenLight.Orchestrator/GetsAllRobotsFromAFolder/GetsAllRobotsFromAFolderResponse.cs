using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsAllRobotsFromAFolderResponse
    {
        [JsonProperty("value")]
        public List<Value41> Value { get; set; }
    }

    public class Value41
    {
        [JsonProperty("HostingType")]
        public string HostingType { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }

        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("UserFullName")]
        public string UserFullName { get; set; }

        [JsonProperty("UserKey")]
        public string UserKey { get; set; }

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
        public ExecutionSettings5 ExecutionSettings { get; set; }

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

    public class ExecutionSettings5
    {
        [JsonProperty("elitb11")]
        public Elitb11 Elitb11 { get; set; }

        [JsonProperty("ipsuma0")]
        public Ipsuma0 Ipsuma0 { get; set; }

        [JsonProperty("laborise")]
        public Laborise Laborise { get; set; }

        [JsonProperty("consecteturf2")]
        public Consecteturf2 Consecteturf2 { get; set; }

        [JsonProperty("nostrud0ed")]
        public Nostrud0ed Nostrud0ed { get; set; }

        [JsonProperty("suntd4")]
        public Suntd4 Suntd4 { get; set; }

        [JsonProperty("est_c74")]
        public EstC74 EstC74 { get; set; }

        [JsonProperty("non_1")]
        public Non1 Non1 { get; set; }

        [JsonProperty("non6f6")]
        public Non6f6 Non6f6 { get; set; }

        [JsonProperty("magna_6")]
        public Magna6 Magna6 { get; set; }

        [JsonProperty("id_2")]
        public Id2 Id2 { get; set; }

        [JsonProperty("adipisicing_d1_")]
        public AdipisicingD1 AdipisicingD1 { get; set; }

        [JsonProperty("velit_3")]
        public Velit3 Velit3 { get; set; }

        [JsonProperty("in18")]
        public In18 In18 { get; set; }

        [JsonProperty("dolore_5d")]
        public Dolore5d Dolore5d { get; set; }

        [JsonProperty("nisi3")]
        public Nisi3 Nisi3 { get; set; }

        [JsonProperty("dolore__7")]
        public Dolore7 Dolore7 { get; set; }

        [JsonProperty("ullamco_90d")]
        public Ullamco90d Ullamco90d { get; set; }

        [JsonProperty("culpa_a03")]
        public CulpaA03 CulpaA03 { get; set; }

        [JsonProperty("id92e")]
        public Id92e Id92e { get; set; }
    }

    public class AdipisicingD1
    {
    }

    public class Consecteturf2
    {
    }

    public class CulpaA03
    {
    }

    public class Dolore5d
    {
    }

    public class Dolore7
    {
    }

    public class Elitb11
    {
    }

    public class EstC74
    {
    }

    public class Id2
    {
    }

    public class Id92e
    {
    }

    public class In18
    {
    }

    public class Ipsuma0
    {
    }

    public class Laborise
    {
    }

    public class Magna6
    {
    }

    public class Nisi3
    {
    }

    public class Non1
    {
    }

    public class Non6f6
    {
    }

    public class Nostrud0ed
    {
    }

    public class Suntd4
    {
    }

    public class Ullamco90d
    {
    }

    public class Velit3
    {
    }
}