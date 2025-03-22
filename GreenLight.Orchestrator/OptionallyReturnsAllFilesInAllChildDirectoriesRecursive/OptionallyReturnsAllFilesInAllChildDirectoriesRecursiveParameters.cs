using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class OptionallyReturnsAllFilesInAllChildDirectoriesRecursiveParameters : IQueryParameters
    {
        /// <summary>
        /// The directory path
        /// </summary>
        public string Directory { get; set; }
        
        /// <summary>
        /// Recurse subdirectories (flat view)
        /// </summary>
        public string Recursive { get; set; }
        
        /// <summary>
        /// Files listing filter
        /// </summary>
        public string FileNameGlob { get; set; }
        
        /// <summary>
        /// Indicates the related entities to be represented inline. The maximum depth is 2.
        /// </summary>
        public string Expand { get; set; }
        
        /// <summary>
        /// Restricts the set of items returned. The maximum number of expressions is 100.
        /// </summary>
        public string Filter { get; set; }
        
        /// <summary>
        /// Limits the properties returned in the result.
        /// </summary>
        public string Select { get; set; }
        
        /// <summary>
        /// Specifies the order in which items are returned. The maximum number of expressions is 5.
        /// </summary>
        public string Orderby { get; set; }
        
        /// <summary>
        /// Number of files to return
        /// </summary>
        public string Top { get; set; }
        
        /// <summary>
        /// Number of files to skip
        /// </summary>
        public string Skip { get; set; }
        
        /// <summary>
        /// Indicates whether the total count of items within a collection are returned in the result.
        /// </summary>
        public string Count { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "directory",
                    Directory
                },
                {
                    "recursive",
                    Recursive
                },
                {
                    "fileNameGlob",
                    FileNameGlob
                },
                {
                    "",
                    Expand
                },
                {
                    "",
                    Filter
                },
                {
                    "",
                    Select
                },
                {
                    "",
                    Orderby
                },
                {
                    "",
                    Top
                },
                {
                    "",
                    Skip
                },
                {
                    "",
                    Count
                }
            };
        }
    }
}