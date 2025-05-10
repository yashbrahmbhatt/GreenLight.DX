using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLight.DX.Docs.Project.Models;

namespace GreenLight.DX.Docs.Project
{
    public class ProjectEditor : BaseEditor
    {
        public ProjectJSON ProjectJSON { get; set; }

        public ProjectEditor(string filePath)
        {
            FilePath = filePath;
            var raw = File.ReadAllText(FilePath);
            ProjectJSON = JsonConvert.DeserializeObject<ProjectJSON>(raw);
        }

        public string ToMarkdown(string template)
        {
            var depsTable = new DataTable("Dependencies");
            depsTable.Columns.Add("Package Name");
            depsTable.Columns.Add("Version");
            foreach (var dep in ProjectJSON.Dependencies) depsTable.Rows.Add(dep.Key, dep.Value.Replace("[", "").Replace("]", ""));
            return template.Replace("{Name}", ProjectJSON.Name)
                    .Replace("{Description}", ProjectJSON.Description)
                    .Replace("{Type}", ProjectJSON.DesignOptions.OutputType)
                    .Replace("{Version}", ProjectJSON.ProjectVersion)
                    .Replace("{StudioVersion}", ProjectJSON.StudioVersion)
                    .Replace("{Dependencies}", Helpers.GenerateMarkdownTable(depsTable))
                    .Replace("{EntryPoints}", ProjectJSON.EntryPoints != null ? Helpers.GenerateMarkdownTable(ProjectJSON.EntryPoints?.Select(e => e.FilePath), "Entry Points") : "")
                    .Replace("{Language}", ProjectJSON.ExpressionLanguage);
        }
    }
}
