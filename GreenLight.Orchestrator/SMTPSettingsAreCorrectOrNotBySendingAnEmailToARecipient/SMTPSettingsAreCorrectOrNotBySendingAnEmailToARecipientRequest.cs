using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class SMTPSettingsAreCorrectOrNotBySendingAnEmailToARecipientRequest
    {
        [JsonProperty("sendTo")]
        public string SendTo { get; set; }

        [JsonProperty("smtpSettingModel")]
        public SmtpSettingModel SmtpSettingModel { get; set; }
    }

    public class SmtpSettingModel
    {
        [JsonProperty("Host")]
        public string Host { get; set; }

        [JsonProperty("Port")]
        public string Port { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("EnableSsl")]
        public string EnableSsl { get; set; }

        [JsonProperty("UseDefaultCredentials")]
        public string UseDefaultCredentials { get; set; }

        [JsonProperty("DefaultFromAddress")]
        public string DefaultFromAddress { get; set; }

        [JsonProperty("DefaultFromDisplayName")]
        public string DefaultFromDisplayName { get; set; }
    }
}