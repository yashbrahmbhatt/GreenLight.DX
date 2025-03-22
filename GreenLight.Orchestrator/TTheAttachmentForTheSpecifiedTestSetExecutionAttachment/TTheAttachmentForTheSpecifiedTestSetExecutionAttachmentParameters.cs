using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class TTheAttachmentForTheSpecifiedTestSetExecutionAttachmentParameters : IQueryParameters
    {
        /// <summary>
        /// Id of the test set execution attachment
        /// </summary>
        public string TestSetExecutionAttachmentId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "testSetExecutionAttachmentId",
                    TestSetExecutionAttachmentId
                }
            };
        }
    }
}