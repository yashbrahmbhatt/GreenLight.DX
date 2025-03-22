using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class TheAttachmentForTheSpecifiedTestCaseExecutionAttachmentParameters : IQueryParameters
    {
        /// <summary>
        /// Id of the test case execution attachment
        /// </summary>
        public string TestCaseExecutionAttachmentId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testCaseExecutionAttachmentId",
                    TestCaseExecutionAttachmentId
                }
            };
        }
    }
}