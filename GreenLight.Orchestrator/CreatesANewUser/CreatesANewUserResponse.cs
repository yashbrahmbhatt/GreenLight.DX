using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewUserResponse
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
}