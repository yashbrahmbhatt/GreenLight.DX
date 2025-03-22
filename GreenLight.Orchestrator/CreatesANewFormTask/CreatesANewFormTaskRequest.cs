using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewFormTaskRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("formLayout")]
        public Data FormLayout { get; set; }

        [JsonProperty("formLayoutId")]
        public string FormLayoutId { get; set; }

        [JsonProperty("bulkFormLayoutId")]
        public string BulkFormLayoutId { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("taskCatalogName")]
        public string TaskCatalogName { get; set; }

        [JsonProperty("externalTag")]
        public string ExternalTag { get; set; }

        [JsonProperty("tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("parentOperationId")]
        public string ParentOperationId { get; set; }
    }

    public class Tags
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("DisplayValue")]
        public string DisplayValue { get; set; }
    }
}