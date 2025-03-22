using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class CancelsTheSpecifiedTestCaseExecutionParameters : IQueryParameters
    {
        /// <summary>
        /// Id for the test case execution to be canceled
        /// </summary>
        public string TestCaseExecutionId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testCaseExecutionId",
                    TestCaseExecutionId
                }
            };
        }
    }
}