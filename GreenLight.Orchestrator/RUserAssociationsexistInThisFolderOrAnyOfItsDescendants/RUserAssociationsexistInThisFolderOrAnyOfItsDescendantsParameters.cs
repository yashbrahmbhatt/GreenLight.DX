using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UiPathWebApi190
{
    public class RUserAssociationsexistInThisFolderOrAnyOfItsDescendantsParameters : IQueryParameters
    {
        public string Key { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "key",
                    Key
                }
            };
        }
    }
}