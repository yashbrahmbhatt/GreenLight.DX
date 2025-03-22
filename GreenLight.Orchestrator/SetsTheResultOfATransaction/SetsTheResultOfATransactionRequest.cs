using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SetsTheResultOfATransactionRequest
    {
        [JsonProperty("transactionResult")]
        public TransactionResult TransactionResult { get; set; }
    }

    public class TransactionResult
    {
        [JsonProperty("IsSuccessful")]
        public string IsSuccessful { get; set; }

        [JsonProperty("ProcessingException")]
        public ProcessingException ProcessingException { get; set; }

        [JsonProperty("DeferDate")]
        public string DeferDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("Output")]
        public Output3 Output { get; set; }

        [JsonProperty("Analytics")]
        public Analytics3 Analytics { get; set; }

        [JsonProperty("Progress")]
        public string Progress { get; set; }

        [JsonProperty("OperationId")]
        public string OperationId { get; set; }
    }

    public class Output3
    {
        [JsonProperty("mollit_59c")]
        public Mollit59c Mollit59c { get; set; }

        [JsonProperty("ut___2")]
        public Ut2 Ut2 { get; set; }

        [JsonProperty("dolore_41c")]
        public Dolore41c Dolore41c { get; set; }
    }

    public class Analytics3
    {
        [JsonProperty("sit1f")]
        public Sit1f Sit1f { get; set; }
    }

    public class Dolore41c
    {
    }

    public class Mollit59c
    {
    }

    public class Sit1f
    {
    }

    public class Ut2
    {
    }
}