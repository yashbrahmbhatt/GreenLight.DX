using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class AmetersAndNotifiesTheRespectiveRobotsAboutThePendingJobRequest
    {
        [JsonProperty("startInfo")]
        public StartInfo StartInfo { get; set; }
    }

    public class StartInfo
    {
        [JsonProperty("ReleaseKey")]
        public string ReleaseKey { get; set; }

        [JsonProperty("ReleaseName")]
        public string ReleaseName { get; set; }

        [JsonProperty("Strategy")]
        public string Strategy { get; set; }

        [JsonProperty("RobotIds")]
        public List<string> RobotIds { get; set; }

        [JsonProperty("MachineSessionIds")]
        public List<string> MachineSessionIds { get; set; }

        [JsonProperty("NoOfRobots")]
        public string NoOfRobots { get; set; }

        [JsonProperty("JobsCount")]
        public string JobsCount { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("JobPriority")]
        public string JobPriority { get; set; }

        [JsonProperty("SpecificPriorityValue")]
        public string SpecificPriorityValue { get; set; }

        [JsonProperty("RuntimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("InputArguments")]
        public string InputArguments { get; set; }

        [JsonProperty("EnvironmentVariables")]
        public string EnvironmentVariables { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("MachineRobots")]
        public List<MachineRobots> MachineRobots { get; set; }

        [JsonProperty("TargetFramework")]
        public string TargetFramework { get; set; }

        [JsonProperty("ResumeOnSameContext")]
        public string ResumeOnSameContext { get; set; }

        [JsonProperty("BatchExecutionKey")]
        public string BatchExecutionKey { get; set; }

        [JsonProperty("RequiresUserInteraction")]
        public string RequiresUserInteraction { get; set; }

        [JsonProperty("StopProcessExpression")]
        public string StopProcessExpression { get; set; }

        [JsonProperty("StopStrategy")]
        public string StopStrategy { get; set; }

        [JsonProperty("KillProcessExpression")]
        public string KillProcessExpression { get; set; }

        [JsonProperty("RemoteControlAccess")]
        public string RemoteControlAccess { get; set; }

        [JsonProperty("AlertPendingExpression")]
        public string AlertPendingExpression { get; set; }

        [JsonProperty("AlertRunningExpression")]
        public string AlertRunningExpression { get; set; }

        [JsonProperty("RunAsMe")]
        public string RunAsMe { get; set; }

        [JsonProperty("ParentOperationId")]
        public string ParentOperationId { get; set; }

        [JsonProperty("AutopilotForRobots")]
        public AutopilotForRobots AutopilotForRobots { get; set; }

        [JsonProperty("ProfilingOptions")]
        public string ProfilingOptions { get; set; }

        [JsonProperty("FpsContext")]
        public string FpsContext { get; set; }

        [JsonProperty("FpsProperties")]
        public string FpsProperties { get; set; }

        [JsonProperty("TraceId")]
        public string TraceId { get; set; }

        [JsonProperty("ParentSpanId")]
        public string ParentSpanId { get; set; }

        [JsonProperty("EntryPointPath")]
        public string EntryPointPath { get; set; }
    }

    public class MachineRobots
    {
        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("RobotUserName")]
        public string RobotUserName { get; set; }
    }
}