using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheSessionsForTheCurrentFolderResponse
    {
        [JsonProperty("value")]
        public List<Value43> Value { get; set; }
    }

    public class Robot
    {
        [JsonProperty("HostingType")]
        public string HostingType { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("License")]
        public License License { get; set; }

        [JsonProperty("User")]
        public Value26 User { get; set; }

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
        public ExecutionSettings6 ExecutionSettings { get; set; }

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

    public class Value43
    {
        [JsonProperty("Robot")]
        public Robot Robot { get; set; }

        [JsonProperty("HostMachineName")]
        public string HostMachineName { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Job")]
        public GetsASingleJobResponse Job { get; set; }

        [JsonProperty("ReportingTime")]
        public string ReportingTime { get; set; }

        [JsonProperty("Info")]
        public string Info { get; set; }

        [JsonProperty("IsUnresponsive")]
        public string IsUnresponsive { get; set; }

        [JsonProperty("LicenseErrorCode")]
        public string LicenseErrorCode { get; set; }

        [JsonProperty("OrganizationUnitId")]
        public string OrganizationUnitId { get; set; }

        [JsonProperty("FolderName")]
        public string FolderName { get; set; }

        [JsonProperty("RobotSessionType")]
        public string RobotSessionType { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("DebugModeExpirationDate")]
        public string DebugModeExpirationDate { get; set; }

        [JsonProperty("UpdateInfo")]
        public UpdateInfo2 UpdateInfo { get; set; }

        [JsonProperty("InstallationId")]
        public string InstallationId { get; set; }

        [JsonProperty("Platform")]
        public string Platform { get; set; }

        [JsonProperty("EndpointDetection")]
        public string EndpointDetection { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class ExecutionSettings6
    {
        [JsonProperty("irure_7")]
        public Irure7 Irure7 { get; set; }

        [JsonProperty("mollit_3")]
        public Mollit3 Mollit3 { get; set; }

        [JsonProperty("consectetur734")]
        public Consectetur734 Consectetur734 { get; set; }

        [JsonProperty("irure_ce")]
        public IrureCe IrureCe { get; set; }

        [JsonProperty("sit7f")]
        public Sit7f Sit7f { get; set; }

        [JsonProperty("et8")]
        public Et8 Et8 { get; set; }

        [JsonProperty("et_a")]
        public EtA EtA { get; set; }

        [JsonProperty("laborum_b7")]
        public LaborumB7 LaborumB7 { get; set; }

        [JsonProperty("ine2e")]
        public Ine2e Ine2e { get; set; }

        [JsonProperty("cillum_f")]
        public CillumF CillumF { get; set; }

        [JsonProperty("aliqua_e8")]
        public AliquaE8 AliquaE8 { get; set; }

        [JsonProperty("laboris9")]
        public Laboris9 Laboris9 { get; set; }

        [JsonProperty("do99")]
        public Do99 Do99 { get; set; }

        [JsonProperty("nulla_5")]
        public Nulla5 Nulla5 { get; set; }

        [JsonProperty("voluptate_4")]
        public Voluptate4 Voluptate4 { get; set; }

        [JsonProperty("aliquip3a7")]
        public Aliquip3a7 Aliquip3a7 { get; set; }
    }

    public class UpdateInfo2
    {
        [JsonProperty("updateStatus")]
        public string UpdateStatus { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("targetUpdateVersion")]
        public string TargetUpdateVersion { get; set; }

        [JsonProperty("isCommunity")]
        public string IsCommunity { get; set; }

        [JsonProperty("statusInfo")]
        public string StatusInfo { get; set; }
    }

    public class License
    {
        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class AliquaE8
    {
    }

    public class Aliquip3a7
    {
    }

    public class CillumF
    {
    }

    public class Consectetur734
    {
    }

    public class Do99
    {
    }

    public class Et8
    {
    }

    public class EtA
    {
    }

    public class Ine2e
    {
    }

    public class Irure7
    {
    }

    public class IrureCe
    {
    }

    public class Laboris9
    {
    }

    public class LaborumB7
    {
    }

    public class Mollit3
    {
    }

    public class Nulla5
    {
    }

    public class Sit7f
    {
    }

    public class Voluptate4
    {
    }
}