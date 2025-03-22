using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class DeleteAllItemsFromATestDataQueueParameters : IQueryParameters
    {
        /// <summary>
        /// The name of the test data queue
        /// </summary>
        public string QueueName { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "queueName",
                    QueueName
                }
            };
        }
    }
}