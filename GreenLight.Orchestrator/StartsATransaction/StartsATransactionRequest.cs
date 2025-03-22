using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class StartsATransactionRequest
    {
        [JsonProperty("transactionData")]
        public TransactionData TransactionData { get; set; }
    }

    public class TransactionData
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RobotIdentifier")]
        public string RobotIdentifier { get; set; }

        [JsonProperty("SpecificContent")]
        public SpecificContent4 SpecificContent { get; set; }

        [JsonProperty("DeferDate")]
        public string DeferDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("Reference")]
        public string Reference { get; set; }

        [JsonProperty("ReferenceFilterOption")]
        public string ReferenceFilterOption { get; set; }

        [JsonProperty("ParentOperationId")]
        public string ParentOperationId { get; set; }
    }

    public class SpecificContent4
    {
        [JsonProperty("elit_a9")]
        public ElitA9 ElitA9 { get; set; }

        [JsonProperty("adipisicing8_9")]
        public Adipisicing89 Adipisicing89 { get; set; }
    }

    public class Adipisicing89
    {
    }

    public class ElitA9
    {
    }
}