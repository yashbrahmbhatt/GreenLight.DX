using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class StartATestSetExecutionParameters : IQueryParameters
    {
        public string TestSetId { get; set; }
        public string TestSetKey { get; set; }
        /// <summary>
        /// Specifies how was the execution triggered
        /// </summary>
        public string TriggerType { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testSetId",
                    TestSetId
                },
                {
                    "testSetKey",
                    TestSetKey
                },
                {
                    "triggerType",
                    TriggerType
                }
            };
        }
    }
}