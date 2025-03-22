using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class HeDistinctionBetweenTheFoldersAssignedDirectlyToTheUserParameters : IQueryParameters
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }
        public string Type { get; set; }
        public string Skip { get; set; }
        public string Take { get; set; }
        public string SearchText { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "username",
                    Username
                },
                {
                    "type",
                    Type
                },
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
                }
            };
        }
    }
}