using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class StartATestSetExecutionWithAdditionalOptionsParameters : IQueryParameters
    {
        public string TestSetId { get; set; }
        public string TestSetKey { get; set; }

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
                }
            };
        }
    }
}