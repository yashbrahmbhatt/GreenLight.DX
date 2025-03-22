using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class HeCurrentUserHasAccessToTheResponseWillBeAListOfFoldersParameters : IQueryParameters
    {
        public string Take { get; set; }
        public string Skip { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "take",
                    Take
                },
                {
                    "skip",
                    Skip
                }
            };
        }
    }
}