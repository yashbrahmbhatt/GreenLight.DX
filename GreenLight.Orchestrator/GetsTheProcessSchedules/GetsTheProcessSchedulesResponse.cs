using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetsTheProcessSchedulesResponse
    {
        [JsonProperty("value")]
        public List<Value30> Value { get; set; }
    }

    public class Value30
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("TimeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Enabled")]
        public string Enabled { get; set; }

        [JsonProperty("ReleaseId")]
        public string ReleaseId { get; set; }

        [JsonProperty("ReleaseKey")]
        public string ReleaseKey { get; set; }

        [JsonProperty("ReleaseName")]
        public string ReleaseName { get; set; }

        [JsonProperty("EntryPointPath")]
        public string EntryPointPath { get; set; }

        [JsonProperty("PackageName")]
        public string PackageName { get; set; }

        [JsonProperty("EnvironmentName")]
        public string EnvironmentName { get; set; }

        [JsonProperty("EnvironmentId")]
        public string EnvironmentId { get; set; }

        [JsonProperty("JobPriority")]
        public string JobPriority { get; set; }

        [JsonProperty("SpecificPriorityValue")]
        public string SpecificPriorityValue { get; set; }

        [JsonProperty("RuntimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("StartProcessCron")]
        public string StartProcessCron { get; set; }

        [JsonProperty("StartProcessCronDetails")]
        public string StartProcessCronDetails { get; set; }

        [JsonProperty("StartProcessCronSummary")]
        public string StartProcessCronSummary { get; set; }

        [JsonProperty("StartProcessNextOccurrence")]
        public string StartProcessNextOccurrence { get; set; }

        [JsonProperty("StartStrategy")]
        public string StartStrategy { get; set; }

        [JsonProperty("ExecutorRobots")]
        public List<ExecutorRobots> ExecutorRobots { get; set; }

        [JsonProperty("StopProcessExpression")]
        public string StopProcessExpression { get; set; }

        [JsonProperty("StopStrategy")]
        public string StopStrategy { get; set; }

        [JsonProperty("KillProcessExpression")]
        public string KillProcessExpression { get; set; }

        [JsonProperty("ExternalJobKey")]
        public string ExternalJobKey { get; set; }

        [JsonProperty("ExternalJobKeyScheduler")]
        public string ExternalJobKeyScheduler { get; set; }

        [JsonProperty("TimeZoneIana")]
        public string TimeZoneIana { get; set; }

        [JsonProperty("UseCalendar")]
        public string UseCalendar { get; set; }

        [JsonProperty("CalendarId")]
        public string CalendarId { get; set; }

        [JsonProperty("CalendarName")]
        public string CalendarName { get; set; }

        [JsonProperty("CalendarKey")]
        public string CalendarKey { get; set; }

        [JsonProperty("StopProcessDate")]
        public string StopProcessDate { get; set; }

        [JsonProperty("InputArguments")]
        public string InputArguments { get; set; }

        [JsonProperty("QueueDefinitionId")]
        public string QueueDefinitionId { get; set; }

        [JsonProperty("QueueDefinitionName")]
        public string QueueDefinitionName { get; set; }

        [JsonProperty("ActivateOnJobComplete")]
        public string ActivateOnJobComplete { get; set; }

        [JsonProperty("ItemsActivationThreshold")]
        public string ItemsActivationThreshold { get; set; }

        [JsonProperty("ItemsPerJobActivationTarget")]
        public string ItemsPerJobActivationTarget { get; set; }

        [JsonProperty("MaxJobsForActivation")]
        public string MaxJobsForActivation { get; set; }

        [JsonProperty("ResumeOnSameContext")]
        public string ResumeOnSameContext { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("MachineRobots")]
        public List<MachineRobots2> MachineRobots { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("AlertPendingExpression")]
        public string AlertPendingExpression { get; set; }

        [JsonProperty("AlertRunningExpression")]
        public string AlertRunningExpression { get; set; }

        [JsonProperty("RunAsMe")]
        public string RunAsMe { get; set; }

        [JsonProperty("ConsecutiveJobFailuresThreshold")]
        public string ConsecutiveJobFailuresThreshold { get; set; }

        [JsonProperty("JobFailuresGracePeriodInHours")]
        public string JobFailuresGracePeriodInHours { get; set; }

        [JsonProperty("IsConnected")]
        public string IsConnected { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class MachineRobots2
    {
        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("RobotUserName")]
        public string RobotUserName { get; set; }

        [JsonProperty("SessionId")]
        public string SessionId { get; set; }

        [JsonProperty("SessionName")]
        public string SessionName { get; set; }
    }

    public class ExecutorRobots
    {
        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}