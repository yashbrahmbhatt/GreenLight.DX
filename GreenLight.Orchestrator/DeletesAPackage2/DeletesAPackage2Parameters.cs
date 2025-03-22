using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class DeletesAPackage2Parameters : IQueryParameters
    {
        public string FeedId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "feedId",
                    FeedId
                }
            };
        }
    }
}