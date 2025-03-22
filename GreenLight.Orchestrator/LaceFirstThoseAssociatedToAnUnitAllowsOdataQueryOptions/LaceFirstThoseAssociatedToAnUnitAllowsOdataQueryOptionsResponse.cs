using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class LaceFirstThoseAssociatedToAnUnitAllowsOdataQueryOptionsResponse
    {
        [JsonProperty("value")]
        public List<Value26> Value { get; set; }
    }

    public class Value26
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("DirectoryIdentifier")]
        public string DirectoryIdentifier { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("LastLoginTime")]
        public string LastLoginTime { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("AuthenticationSource")]
        public string AuthenticationSource { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("IsExternalLicensed")]
        public string IsExternalLicensed { get; set; }

        [JsonProperty("UserRoles")]
        public List<UserRoles> UserRoles { get; set; }

        [JsonProperty("RolesList")]
        public List<string> RolesList { get; set; }

        [JsonProperty("LoginProviders")]
        public List<string> LoginProviders { get; set; }

        [JsonProperty("OrganizationUnits")]
        public List<CreatesAnOrganizationUnitCreatedResponse> OrganizationUnits { get; set; }

        [JsonProperty("TenantId")]
        public string TenantId { get; set; }

        [JsonProperty("TenancyName")]
        public string TenancyName { get; set; }

        [JsonProperty("TenantDisplayName")]
        public string TenantDisplayName { get; set; }

        [JsonProperty("TenantKey")]
        public string TenantKey { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("ProvisionType")]
        public string ProvisionType { get; set; }

        [JsonProperty("LicenseType")]
        public string LicenseType { get; set; }

        [JsonProperty("RobotProvision")]
        public RobotProvision RobotProvision { get; set; }

        [JsonProperty("UnattendedRobot")]
        public UnattendedRobot UnattendedRobot { get; set; }

        [JsonProperty("NotificationSubscription")]
        public NotificationSubscription NotificationSubscription { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("MayHaveUserSession")]
        public string MayHaveUserSession { get; set; }

        [JsonProperty("MayHaveRobotSession")]
        public string MayHaveRobotSession { get; set; }

        [JsonProperty("MayHaveUnattendedSession")]
        public string MayHaveUnattendedSession { get; set; }

        [JsonProperty("MayHavePersonalWorkspace")]
        public string MayHavePersonalWorkspace { get; set; }

        [JsonProperty("RestrictToPersonalWorkspace")]
        public string RestrictToPersonalWorkspace { get; set; }

        [JsonProperty("UpdatePolicy")]
        public UpdatePolicy UpdatePolicy { get; set; }

        [JsonProperty("AccountId")]
        public string AccountId { get; set; }

        [JsonProperty("HasOnlyInheritedPrivileges")]
        public string HasOnlyInheritedPrivileges { get; set; }

        [JsonProperty("ExplicitMayHaveUserSession")]
        public string ExplicitMayHaveUserSession { get; set; }

        [JsonProperty("ExplicitMayHaveRobotSession")]
        public string ExplicitMayHaveRobotSession { get; set; }

        [JsonProperty("ExplicitMayHavePersonalWorkspace")]
        public string ExplicitMayHavePersonalWorkspace { get; set; }

        [JsonProperty("ExplicitRestrictToPersonalWorkspace")]
        public string ExplicitRestrictToPersonalWorkspace { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class NotificationSubscription
    {
        [JsonProperty("Queues")]
        public string Queues { get; set; }

        [JsonProperty("Robots")]
        public string Robots { get; set; }

        [JsonProperty("Jobs")]
        public string Jobs { get; set; }

        [JsonProperty("Schedules")]
        public string Schedules { get; set; }

        [JsonProperty("Tasks")]
        public string Tasks { get; set; }

        [JsonProperty("QueueItems")]
        public string QueueItems { get; set; }

        [JsonProperty("Insights")]
        public string Insights { get; set; }

        [JsonProperty("CloudRobots")]
        public string CloudRobots { get; set; }

        [JsonProperty("Serverless")]
        public string Serverless { get; set; }

        [JsonProperty("Export")]
        public string Export { get; set; }

        [JsonProperty("RateLimitsDaily")]
        public string RateLimitsDaily { get; set; }

        [JsonProperty("RateLimitsRealTime")]
        public string RateLimitsRealTime { get; set; }

        [JsonProperty("AutopilotForRobotsDetectedIssues")]
        public string AutopilotForRobotsDetectedIssues { get; set; }

        [JsonProperty("Webhooks")]
        public string Webhooks { get; set; }
    }

    public class UnattendedRobot
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("CredentialType")]
        public string CredentialType { get; set; }

        [JsonProperty("CredentialExternalName")]
        public string CredentialExternalName { get; set; }

        [JsonProperty("ExecutionSettings")]
        public ExecutionSettings2 ExecutionSettings { get; set; }

        [JsonProperty("LimitConcurrentExecution")]
        public string LimitConcurrentExecution { get; set; }

        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("MachineMappingsCount")]
        public string MachineMappingsCount { get; set; }
    }

    public class ExecutionSettings2
    {
        [JsonProperty("id_e1")]
        public IdE1 IdE1 { get; set; }

        [JsonProperty("in_70")]
        public In70 In70 { get; set; }

        [JsonProperty("anim_27")]
        public Anim27 Anim27 { get; set; }

        [JsonProperty("non_ac2")]
        public NonAc2 NonAc2 { get; set; }

        [JsonProperty("nostrud6")]
        public Nostrud6 Nostrud6 { get; set; }

        [JsonProperty("consequat4")]
        public Consequat4 Consequat4 { get; set; }

        [JsonProperty("dolor94")]
        public Dolor94 Dolor94 { get; set; }
    }

    public class UserRoles
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("RoleId")]
        public string RoleId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("RoleName")]
        public string RoleName { get; set; }

        [JsonProperty("RoleType")]
        public string RoleType { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class RobotProvision
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("ExecutionSettings")]
        public ExecutionSettings2 ExecutionSettings { get; set; }

        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("RobotType")]
        public string RobotType { get; set; }
    }

    public class Anim27
    {
    }

    public class Consequat4
    {
    }

    public class Dolor94
    {
    }

    public class IdE1
    {
    }

    public class In70
    {
    }

    public class NonAc2
    {
    }

    public class Nostrud6
    {
    }
}