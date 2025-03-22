using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class CreatesANewAppTaskRequest
    {
        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("taskDefinitionId")]
        public string TaskDefinitionId { get; set; }

        [JsonProperty("taskDefinitionVersion")]
        public string TaskDefinitionVersion { get; set; }

        [JsonProperty("appProcessKey")]
        public string AppProcessKey { get; set; }

        [JsonProperty("folderKey")]
        public string FolderKey { get; set; }

        [JsonProperty("fpsContext")]
        public Data FpsContext { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("appType")]
        public string AppType { get; set; }

        [JsonProperty("isActionableMessageEnabled")]
        public string IsActionableMessageEnabled { get; set; }

        [JsonProperty("actionableMessageMetaData")]
        public ActionableMessageMetaData ActionableMessageMetaData { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

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

    public class Fields
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("placeHolderText")]
        public string PlaceHolderText { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("isHeader")]
        public string IsHeader { get; set; }

        [JsonProperty("isRequired")]
        public string IsRequired { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }

        [JsonProperty("horizontalAlignment")]
        public string HorizontalAlignment { get; set; }
    }

    public class Actions
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("isPrimary")]
        public string IsPrimary { get; set; }
    }

    public class ActionSet
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("actions")]
        public List<Actions> Actions { get; set; }
    }

    public class ActionableMessageMetaData
    {
        [JsonProperty("fieldSet")]
        public FieldSet FieldSet { get; set; }

        [JsonProperty("actionSet")]
        public ActionSet ActionSet { get; set; }
    }

    public class FieldSet
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fields")]
        public List<Fields> Fields { get; set; }
    }
}