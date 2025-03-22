using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class GetsADirectDownloadURLForBlobFileParameters : IQueryParameters
    {
        /// <summary>
        /// The BlobFile full path
        /// </summary>
        public string Path { get; set; }
        
        /// <summary>
        /// URL expiration time
        /// </summary>
        public string ExpiryInMinutes { get; set; }
        
        /// <summary>
        /// Indicates the related entities to be represented inline. The maximum depth is 2.
        /// </summary>
        public string Expand { get; set; }
        
        /// <summary>
        /// Limits the properties returned in the result.
        /// </summary>
        public string Select { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "path",
                    Path
                },
                {
                    "expiryInMinutes",
                    ExpiryInMinutes
                },
                {
                    "",
                    Expand
                },
                {
                    "",
                    Select
                }
            };
        }
    }
}