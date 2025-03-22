using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class PecifiedTestCaseExecutionsWithinTheSameTestSetExecutionRequest
    {
        [JsonProperty("testCaseExecutions")]
        public List<TestCaseExecutions> TestCaseExecutions { get; set; }

        [JsonProperty("robotId")]
        public string RobotId { get; set; }

        [JsonProperty("machineId")]
        public string MachineId { get; set; }

        [JsonProperty("machineSessionId")]
        public string MachineSessionId { get; set; }

        [JsonProperty("runtimeType")]
        public string RuntimeType { get; set; }

        [JsonProperty("enforceExecutionOrder")]
        public string EnforceExecutionOrder { get; set; }
    }

    public class TestCaseExecutions
    {
        [JsonProperty("testCaseExecutionId")]
        public string TestCaseExecutionId { get; set; }

        [JsonProperty("inputArguments")]
        public InputArguments InputArguments { get; set; }

        [JsonProperty("executionOrder")]
        public string ExecutionOrder { get; set; }
    }

    public class InputArguments
    {
    }
}