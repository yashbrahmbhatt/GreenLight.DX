using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class ReturnsAJsonWithTranslationResourcesParameters : IQueryParameters
    {
        public string Lang { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "lang",
                    Lang
                }
            };
        }
    }
}