using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class CancelsTheSpecifiedTestSetExecutionParameters : IQueryParameters
    {
        /// <summary>
        /// Id for the test set execution to be canceled
        /// </summary>
        public string TestSetExecutionId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testSetExecutionId",
                    TestSetExecutionId
                }
            };
        }
    }
}