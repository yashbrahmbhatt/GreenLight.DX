using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class GetsTheLicensingUsageStatisticsParameters : IQueryParameters
    {
        /// <summary>
        /// The Tenant's Id - can be used when authenticated as Host
        /// </summary>
        public string TenantId { get; set; }
        
        /// <summary>
        /// Number of reported license usage days
        /// </summary>
        public string Days { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "tenantId",
                    TenantId
                },
                {
                    "days",
                    Days
                }
            };
        }
    }
}