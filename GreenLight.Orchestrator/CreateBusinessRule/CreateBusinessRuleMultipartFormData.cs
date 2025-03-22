using System;
using System.Collections.Generic;
using System.Net.Http;

namespace UiPathWebApi190
{
    public class CreateBusinessRuleMultipartFormData : IMultipartFormData
    {
        /// <summary>
        /// (Required) 
        /// </summary>
        public StreamContent File { get; set; }
        
        /// <summary>
        /// (Required) 
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// (Required) The BusinessRuleDto object
        /// </summary>
        public string BusinessRule { get; set; }

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
                    new StringContent(BusinessRule),
                    "businessRule"
                }
            };
        }
    }
}