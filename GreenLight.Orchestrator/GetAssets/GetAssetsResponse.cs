using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class GetAssetsResponse
    {
        [JsonProperty("value")]
        public List<Value2> Value { get; set; }
    }

    public class Value2
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ValueScope")]
        public string ValueScope { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("CanBeDeleted")]
        public string CanBeDeleted { get; set; }

        [JsonProperty("ValueType")]
        public string ValueType { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("StringValue")]
        public string StringValue { get; set; }

        [JsonProperty("BoolValue")]
        public string BoolValue { get; set; }

        [JsonProperty("IntValue")]
        public string IntValue { get; set; }

        [JsonProperty("CredentialUsername")]
        public string CredentialUsername { get; set; }

        [JsonProperty("CredentialPassword")]
        public string CredentialPassword { get; set; }

        [JsonProperty("ExternalName")]
        public string ExternalName { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("KeyValueList")]
        public List<KeyValueList> KeyValueList { get; set; }

        [JsonProperty("HasDefaultValue")]
        public string HasDefaultValue { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("RobotValues")]
        public List<RobotValues> RobotValues { get; set; }

        [JsonProperty("UserValues")]
        public List<UserValues> UserValues { get; set; }

        [JsonProperty("Tags")]
        public List<Tags> Tags { get; set; }

        [JsonProperty("FoldersCount")]
        public string FoldersCount { get; set; }

        [JsonProperty("LastModificationTime")]
        public string LastModificationTime { get; set; }

        [JsonProperty("LastModifierUserId")]
        public string LastModifierUserId { get; set; }

        [JsonProperty("CreationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("CreatorUserId")]
        public string CreatorUserId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class UserValues
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("ValueType")]
        public string ValueType { get; set; }

        [JsonProperty("StringValue")]
        public string StringValue { get; set; }

        [JsonProperty("BoolValue")]
        public string BoolValue { get; set; }

        [JsonProperty("IntValue")]
        public string IntValue { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("CredentialUsername")]
        public string CredentialUsername { get; set; }

        [JsonProperty("CredentialPassword")]
        public string CredentialPassword { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("ExternalName")]
        public string ExternalName { get; set; }

        [JsonProperty("KeyValueList")]
        public List<KeyValueList> KeyValueList { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class RobotValues
    {
        [JsonProperty("RobotId")]
        public string RobotId { get; set; }

        [JsonProperty("RobotName")]
        public string RobotName { get; set; }

        [JsonProperty("KeyTrail")]
        public string KeyTrail { get; set; }

        [JsonProperty("ValueType")]
        public string ValueType { get; set; }

        [JsonProperty("StringValue")]
        public string StringValue { get; set; }

        [JsonProperty("BoolValue")]
        public string BoolValue { get; set; }

        [JsonProperty("IntValue")]
        public string IntValue { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("CredentialUsername")]
        public string CredentialUsername { get; set; }

        [JsonProperty("CredentialPassword")]
        public string CredentialPassword { get; set; }

        [JsonProperty("ExternalName")]
        public string ExternalName { get; set; }

        [JsonProperty("CredentialStoreId")]
        public string CredentialStoreId { get; set; }

        [JsonProperty("KeyValueList")]
        public List<KeyValueList> KeyValueList { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
    }

    public class KeyValueList
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}