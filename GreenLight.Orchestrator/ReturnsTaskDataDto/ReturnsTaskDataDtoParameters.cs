using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class ReturnsTaskDataDtoParameters : IQueryParameters
    {
        /// <summary>
        /// Task id
        /// </summary>
        public string TaskId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "taskId",
                    TaskId
                }
            };
        }
    }
}