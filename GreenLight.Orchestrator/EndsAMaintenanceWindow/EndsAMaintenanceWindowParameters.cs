using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class EndsAMaintenanceWindowParameters : IQueryParameters
    {
        public string TenantId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "tenantId",
                    TenantId
                }
            };
        }
    }
}