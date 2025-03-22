using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class DeletesTaskDefintionVersionParameters : IQueryParameters
    {
        /// <summary>
        /// Version of task definition to be deleted
        /// </summary>
        public string TaskDefinitionVersion { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "taskDefinitionVersion",
                    TaskDefinitionVersion
                }
            };
        }
    }
}