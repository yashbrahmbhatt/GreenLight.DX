using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class MoveAFolderParameters : IQueryParameters
    {
        /// <summary>
        /// Id of the target parent
        /// </summary>
        public string TargetParentId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "targetParentId",
                    TargetParentId
                }
            };
        }
    }
}