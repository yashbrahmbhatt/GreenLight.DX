using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Shared.Editor.Project
{
    public class Project : BaseEditor
    {
        public string ProjectName;
        public string Description;
        public DataTable EntryPoints = new DataTable();
        public string Language;
        public string ProjectVersion;
        public string StudioVersion;
        public string Type;
        public DataTable Dependencies = new DataTable();
        public DataTable FileInfoCollection = new DataTable();

        public class InvalidProjectJsonException : Exception
        {
            public InvalidProjectJsonException(string message) : base("Project json was not valid: " + message)
            {
            }
        }
        public Project(string filePath)
        {
            Console.WriteLine(string.Format("Parsing '{0}' as project.json", filePath));
            FilePath = FilePath;
            var raw = File.ReadAllText(filePath);
            Dependencies.Columns.Add("Name", "".GetType());
            Dependencies.Columns.Add("Version", "".GetType());
            EntryPoints.Columns.Add("FilePath");

            JObject jObj = JObject.Parse(raw);
            ProjectName = jObj["name"]?.Value<string>() ?? throw new InvalidProjectJsonException("Name doesn't exist");
            Description = jObj["description"]?.Value<string>() ?? throw new InvalidProjectJsonException("Description doesn't exist");
            IEnumerable<Object[]> dependencyArrays = jObj["dependencies"]?.Children<JProperty>()
                .Select(c => new object[2]{
                        c.Name,
                        c.Value.ToString().Trim(new char[2]{'[', ']'})
                }) ?? throw new InvalidProjectJsonException("Dependencies don't exist");
            Type = jObj["designOptions"]?.Value<string>("outputType") ?? throw new InvalidProjectJsonException("Output type doesn't exist");
            FileInfoCollection = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(jObj["designOptions"]?["fileInfoCollection"])) ?? throw new InvalidProjectJsonException("File info collection doesn't exist");
            var entries = jObj["entryPoints"]?.Children<JObject>().Select(c =>
                System.IO.Path.Combine(Directory.GetCurrentDirectory(), c.Value<string>("filePath") ?? throw new InvalidProjectJsonException("Entry point file path doesn't exist"))
            ) ?? throw new InvalidProjectJsonException("Entry paths don't exist");
            foreach (var entry in entries) EntryPoints.Rows.Add(new object[1] { System.IO.Path.GetRelativePath(Directory.GetCurrentDirectory(), entry) });

            Language = jObj["expressionLanguage"]?.Value<string>() ?? throw new InvalidProjectJsonException("Expression language doesn't exist");
            ProjectVersion = jObj["projectVersion"]?.Value<string>() ?? throw new InvalidProjectJsonException("Project version doesn't exist");
            StudioVersion = jObj["studioVersion"]?.Value<string>() ?? throw new InvalidProjectJsonException("Studio version doesn't exist");

            foreach (var arr in dependencyArrays)
            {
                Dependencies.Rows.Add(arr);
            }
        }
    }
}
