using System;
using System.Collections.Generic;
using System.Net.Http;

namespace UiPathWebApi190
{
    public class UpdateBusinessRuleMultipartFormData : IMultipartFormData
    {
        /// <summary>
        /// (Required) The BusinessRuleDto object
        /// </summary>
        public string BusinessRule { get; set; }
        public StreamContent File { get; set; }
        public string FileName { get; set; }

        public MultipartFormDataContent ToMultipartFormData()
        {
            return new MultipartFormDataContent()
            {
                {
                    new StringContent(BusinessRule),
                    "businessRule"
                },
                {
                    File,
                    "file",
                    FileName
                }
            };
        }
    }
}