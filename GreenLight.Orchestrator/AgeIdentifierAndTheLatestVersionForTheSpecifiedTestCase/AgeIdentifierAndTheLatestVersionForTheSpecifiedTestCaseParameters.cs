using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class AgeIdentifierAndTheLatestVersionForTheSpecifiedTestCaseParameters : IQueryParameters
    {
        public string TestCaseUniqueId { get; set; }
        public string PackageIdentifier { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testCaseUniqueId",
                    TestCaseUniqueId
                },
                {
                    "packageIdentifier",
                    PackageIdentifier
                }
            };
        }
    }
}