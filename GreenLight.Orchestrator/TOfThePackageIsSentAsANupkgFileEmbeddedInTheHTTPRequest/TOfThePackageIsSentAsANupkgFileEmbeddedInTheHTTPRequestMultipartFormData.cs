using System;
using System.Collections.Generic;
using System.Net.Http;

namespace UiPathWebApi190
{
    public class TOfThePackageIsSentAsANupkgFileEmbeddedInTheHTTPRequestMultipartFormData : IMultipartFormData
    {
        /// <summary>
        /// (Required) 
        /// </summary>
        public StreamContent File { get; set; }
        
        /// <summary>
        /// (Required) 
        /// </summary>
        public string FileName { get; set; }
        public StreamContent File2 { get; set; }
        public string FileName2 { get; set; }
        public StreamContent File3 { get; set; }
        public string FileName3 { get; set; }
        public StreamContent File4 { get; set; }
        public string FileName4 { get; set; }
        public StreamContent File5 { get; set; }
        public string FileName5 { get; set; }
        public StreamContent File6 { get; set; }
        public string FileName6 { get; set; }
        public StreamContent File7 { get; set; }
        public string FileName7 { get; set; }
        public StreamContent File8 { get; set; }
        public string FileName8 { get; set; }
        public StreamContent File9 { get; set; }
        public string FileName9 { get; set; }
        public StreamContent File10 { get; set; }
        public string FileName10 { get; set; }

        public MultipartFormDataContent ToMultipartFormData()
        {
            return new MultipartFormDataContent()
            {
                {
                    File,
                    "file",
                    FileName
                },
                {
                    File2,
                    "file1",
                    FileName2
                },
                {
                    File3,
                    "file2",
                    FileName3
                },
                {
                    File4,
                    "file3",
                    FileName4
                },
                {
                    File5,
                    "file4",
                    FileName5
                },
                {
                    File6,
                    "file5",
                    FileName6
                },
                {
                    File7,
                    "file6",
                    FileName7
                },
                {
                    File8,
                    "file7",
                    FileName8
                },
                {
                    File9,
                    "file8",
                    FileName9
                },
                {
                    File10,
                    "file9",
                    FileName10
                }
            };
        }
    }
}