using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class EturnsTheFeedIdForAUserAssignedFolderHavingSpecificFeedParameters : IQueryParameters
    {
        public string FolderId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "folderId",
                    FolderId
                }
            };
        }
    }
}