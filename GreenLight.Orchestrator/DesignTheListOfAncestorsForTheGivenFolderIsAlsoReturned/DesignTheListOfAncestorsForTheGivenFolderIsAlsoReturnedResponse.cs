using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UiPathWebApi190
{
    public class DesignTheListOfAncestorsForTheGivenFolderIsAlsoReturnedResponse
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("IsSelectable")]
        public string IsSelectable { get; set; }

        [JsonProperty("IsPersonal")]
        public string IsPersonal { get; set; }

        [JsonProperty("ProvisionType")]
        public string ProvisionType { get; set; }

        [JsonProperty("Ancestors")]
        public List<Folder> Ancestors { get; set; }

        [JsonProperty("ChildrenPage")]
        public List<RsTheUserHasactuallyBeenAssignedToTheFoldersWillBeMarkeResponse> ChildrenPage { get; set; }

        [JsonProperty("ChildrenCount")]
        public string ChildrenCount { get; set; }
    }
}