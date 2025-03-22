using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class StatusVerifyHostAvailibilityParameters : IQueryParameters
    {
        public string Url { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "url",
                    Url
                }
            };
        }
    }
}