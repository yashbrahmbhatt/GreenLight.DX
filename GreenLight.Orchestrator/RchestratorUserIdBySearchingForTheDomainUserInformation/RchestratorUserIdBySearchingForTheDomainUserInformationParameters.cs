using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class RchestratorUserIdBySearchingForTheDomainUserInformationParameters : IQueryParameters
    {
        public string Domain { get; set; }
        public string DirectoryIdentifier { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "domain",
                    Domain
                },
                {
                    "directoryIdentifier",
                    DirectoryIdentifier
                },
                {
                    "userName",
                    UserName
                },
                {
                    "userType",
                    UserType
                }
            };
        }
    }
}