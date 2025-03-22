using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class SearchUsersAndGroupsParameters : IQueryParameters
    {
        public string SearchContext { get; set; }
        public string Domain { get; set; }
        public string Prefix { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "searchContext",
                    SearchContext
                },
                {
                    "domain",
                    Domain
                },
                {
                    "prefix",
                    Prefix
                }
            };
        }
    }
}