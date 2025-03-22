using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class StartATestSetExecutionWithAdditionalOptionsRequest
    {
        [JsonProperty("batchExecutionKey")]
        public string BatchExecutionKey { get; set; }

        [JsonProperty("triggerType")]
        public string TriggerType { get; set; }

        [JsonProperty("testCases")]
        public List<TestCases> TestCases { get; set; }

        [JsonProperty("executeOnlySpecifiedTestCases")]
        public string ExecuteOnlySpecifiedTestCases { get; set; }

        [JsonProperty("robotId")]
        public string RobotId { get; set; }

        [JsonProperty("runtimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("machineId")]
        public string MachineId { get; set; }

        [JsonProperty("machineSessionId")]
        public string MachineSessionId { get; set; }

        [JsonProperty("enforceExecutionOrder")]
        public string EnforceExecutionOrder { get; set; }
    }

    public class TestCases
    {
        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("packageIdentifier")]
        public string PackageIdentifier { get; set; }

        [JsonProperty("executionOrder")]
        public string ExecutionOrder { get; set; }

        [JsonProperty("testManagerTestCaseId")]
        public string TestManagerTestCaseId { get; set; }
    }
}