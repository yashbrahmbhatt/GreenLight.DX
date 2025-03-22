using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class ReturnsFormDtoToRenderTaskFormParameters : IQueryParameters
    {
        /// <summary>
        /// Task id
        /// </summary>
        public string TaskId { get; set; }
        public string ExpandOnFormLayout { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "taskId",
                    TaskId
                },
                {
                    "expandOnFormLayout",
                    ExpandOnFormLayout
                }
            };
        }
    }
}