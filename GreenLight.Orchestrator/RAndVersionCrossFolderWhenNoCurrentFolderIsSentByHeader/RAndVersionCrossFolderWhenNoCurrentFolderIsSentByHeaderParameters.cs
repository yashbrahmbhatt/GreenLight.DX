using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class RAndVersionCrossFolderWhenNoCurrentFolderIsSentByHeaderParameters : IQueryParameters
    {
        public string PackageIdentifier { get; set; }
        public string Version { get; set; }
        /// <summary>
        /// If in a cross-folder scenario, these represent the additional permissions
        ///             required in the folders the data is retrieved from; all permissions in this set must be 
        /// met
        /// </summary>
        public string MandatoryPermissions { get; set; }
        
        /// <summary>
        /// If in a cross-folder scenario, these represent the additional permissions
        ///             required in the folders the data is retrieved from; at least one permission in this set 
        /// must be met
        /// </summary>
        public string AtLeastOnePermissions { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "packageIdentifier",
                    PackageIdentifier
                },
                {
                    "version",
                    Version
                },
                {
                    "mandatoryPermissions",
                    MandatoryPermissions
                },
                {
                    "atLeastOnePermissions",
                    AtLeastOnePermissions
                }
            };
        }
    }
}