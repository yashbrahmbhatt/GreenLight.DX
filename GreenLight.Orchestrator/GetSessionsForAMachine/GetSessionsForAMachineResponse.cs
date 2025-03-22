using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetSessionsForAMachineResponse
    {
        [JsonProperty("value")]
        public List<Value45> Value { get; set; }
    }

    public class Value45
    {
        [JsonProperty("ServiceUserName")]
        public string ServiceUserName { get; set; }

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

    public class Cupidatatfd
    {
    }

    public class In045
    {
    }

    public class In9f
    {
    }

    public class LoremB
    {
    }

    public class Officiaf89
    {
    }

    public class Ut06
    {
    }

    public class Ut469
    {
    }

    public class UtD8
    {
    }
}