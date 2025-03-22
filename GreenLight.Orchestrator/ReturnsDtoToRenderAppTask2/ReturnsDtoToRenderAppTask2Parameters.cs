using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class ReturnsDtoToRenderAppTask2Parameters : IQueryParameters
    {
        /// <summary>
        /// Task key
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