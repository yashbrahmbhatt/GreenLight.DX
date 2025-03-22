using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class DesignTheListOfAncestorsForTheGivenFolderIsAlsoReturnedParameters : IQueryParameters
    {
        public string Skip { get; set; }
        public string Take { get; set; }
        public string FolderId { get; set; }

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
                    "folderId",
                    FolderId
                }
            };
        }
    }
}