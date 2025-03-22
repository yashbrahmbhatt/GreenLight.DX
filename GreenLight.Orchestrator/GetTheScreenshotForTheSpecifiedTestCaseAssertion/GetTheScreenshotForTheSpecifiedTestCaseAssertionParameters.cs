using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class GetTheScreenshotForTheSpecifiedTestCaseAssertionParameters : IQueryParameters
    {
        /// <summary>
        /// Id of the test case assertion
        /// </summary>
        public string TestCaseAssertionId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testCaseAssertionId",
                    TestCaseAssertionId
                }
            };
        }
    }
}