using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class RedSubsetPaginatedOfTheFoldersTheCurrentUserHasAccessToParameters : IQueryParameters
    {
        public string Skip { get; set; }
        public string Take { get; set; }
        public string SearchText { get; set; }
        public string FolderTypes { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "skip",
                    Skip
                },
                {
                    "take",
                    Take
                },
                {
                    "searchText",
                    SearchText
                },
                {
                    "folderTypes",
                    FolderTypes
                }
            };
        }
    }
}