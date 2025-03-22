using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class ReturnsTaskDataDto3Parameters : IQueryParameters
    {
        /// <summary>
        /// Task Key
        /// </summary>
        public string TaskKey { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "taskKey",
                    TaskKey
                }
            };
        }
    }
}