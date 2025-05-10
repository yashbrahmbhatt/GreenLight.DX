using CsvHelper;
using GreenLight.DX.Shared.Services.Orchestrator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GreenLight.DX.Config.Services.Configuration.Models
{
    [Serializable]
    [XmlType(nameof(ResourceItemModel))] // For XML serialization of derived type
    public class ResourceItemModel : ConfigItemModel
    {
        [JsonIgnore]
        [XmlIgnore]
        private OrchestratorService _orchestratorService;

        [JsonProperty(nameof(Path))] // Use nameof
        public string Path { get; set; } = "FilePath";

        [JsonProperty(nameof(Folder))] // Use nameof
        public string Folder { get; set; } = "Folder";

        [JsonProperty(nameof(Bucket))] // Use nameof
        public string Bucket { get; set; } = "Bucket";


        public override object Value { get; set; }

        [JsonProperty(nameof(ResourceType))]
        public ResourceRowType ResourceType { get; set; } = ResourceRowType.LocalOrNetwork;

        public ResourceItemModel() : base() { }
        public ResourceItemModel(IServiceProvider services) : base(services)
        {
            InitializeServices(services);
        }

        public new void InitializeServices(IServiceProvider provider)
        {
            base.InitializeServices(provider);
            _orchestratorService = provider.GetRequiredService<OrchestratorService>();
        }

        public async Task RefreshValue()
        {
            try
            {
                if (ResourceType == ResourceRowType.Orchestrator)
                {
                    // Find the bucket and bucket file
                    Value = await ReadOrchestratorResource();
                }
                else
                {
                    Value = await ReadLocalResource();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving resource: {ex.Message}");
                Value = null;
            }
            return;
        }
        private async Task<object> ReadOrchestratorResource()
        {
            // Find the bucket and bucket file
            var bucket = _orchestratorService.Buckets.FirstOrDefault(b => b.Value.Any(bucket => bucket.Name == Bucket)).Value?.FirstOrDefault(bucket => bucket.Name == Bucket);
            if (bucket == null) return null;
            var bucketFile = _orchestratorService.BucketFiles.FirstOrDefault(b => b.Key.Id == bucket.Id).Value?.FirstOrDefault(file => file.FullPath == Path);
            if (bucketFile == null) return null;

            // Download the file
            string tempFilePath = System.IO.Path.GetTempFileName();
            var res = await _orchestratorService.DownloadBucketFile(bucket, bucketFile, tempFilePath);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            // Read and parse the file
            string fileExtension = System.IO.Path.GetExtension(Path).ToLower();
            return await ParseFileContent(tempFilePath, fileExtension);
        }

        private async Task<object> ReadLocalResource()
        {
            string filePath = System.IO.Path.Combine(Folder, Path);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Local file not found: {filePath}");
                return null;
            }

            string fileExtension = System.IO.Path.GetExtension(Path).ToLower();
            return await ParseFileContent(filePath, fileExtension);
        }
        private async Task<object> ParseFileContent(string filePath, string fileExtension)
        {
            switch (fileExtension)
            {
                case ".txt":
                    return await File.ReadAllTextAsync(filePath);
                case ".csv":
                    return ParseCsv(filePath);
                default:
                    return null;
            }
        }
        private static DataTable ParseCsv(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.Delimiters = new string[] { "," }; // Assuming comma-separated

                // Read headers
                if (!parser.EndOfData)
                {
                    string[] headers = parser.ReadFields();
                    if (headers != null)
                    {
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }
                    }
                }

                // Read data rows
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields != null)
                    {
                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < fields.Length && i < dataTable.Columns.Count; i++)
                        {
                            row[i] = fields[i];
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }

            return dataTable;
        }
    }

    public enum ResourceRowType
    {
        LocalOrNetwork,
        Orchestrator
    }
}
