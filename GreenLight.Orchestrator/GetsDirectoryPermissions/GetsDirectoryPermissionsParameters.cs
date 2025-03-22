using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class GetsDirectoryPermissionsParameters : IQueryParameters
    {
        public string Username { get; set; }
        public string Domain { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "username",
                    Username
                },
                {
                    "domain",
                    Domain
                }
            };
        }
    }
}