using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class StartsAMaintenanceWindowParameters : IQueryParameters
    {
        /// <summary>
        /// Phase - UiPath.Orchestrator.DataContracts.MaintenanceState.Draining or UiPath.Orchestrator.DataContracts.MaintenanceState.Suspended
        /// </summary>
        public string Phase { get; set; }
        
        /// <summary>
        /// Whether to ignore errors during transition
        /// </summary>
        public string Force { get; set; }
        
        /// <summary>
        /// Whether to force-kill running jobs when transitioning to UiPath.Orchestrator.DataContracts.MaintenanceState.Suspended
        /// </summary>
        public string KillJobs { get; set; }
        
        /// <summary>
        /// If tenant id is set, maintenance will start only for this tenant
        /// </summary>
        public string TenantId { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "phase",
                    Phase
                },
                {
                    "force",
                    Force
                },
                {
                    "killJobs",
                    KillJobs
                },
                {
                    "tenantId",
                    TenantId
                }
            };
        }
    }
}