using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using UiPath.Studio.Activities.Api;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Win32;
using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Services.Configuration.Helpers;
using GreenLight.DX.Config.Settings;
using GreenLight.DX.Config.Services.TypeParser;
using GreenLight.DX.Config.Wizards.Configuration.Misc;

namespace GreenLight.DX.Config.Services.Configuration
{

    public class ConfigurationService
    {
        public ProjectModel Project { get; set; }
        public string ConfigurationsFile { get; set; } = null;
        public string ClassesFile { get; set; } = null;
        private readonly IServiceProvider _services;
        private readonly ITypeParserService _typeParserService;
        private readonly IWorkflowDesignApi _workflowDesignApi;


        public ConfigurationService(IServiceProvider services)
        {
            _services = services;
            _workflowDesignApi = services.GetRequiredService<IWorkflowDesignApi>();
            _typeParserService = services.GetRequiredService<ITypeParserService>();
            var settings = _workflowDesignApi.Settings;
            settings.TryGetValue<string>(SettingKeys.Config_ConfigurationsFilePathKey, out var configPath);
            ConfigurationsFile = configPath;
            settings.TryGetValue<string>(SettingKeys.Config_ConfigurationTypesFilePathKey, out var classesPath);
            ClassesFile = classesPath;
            Project = new ProjectModel();
            Project.InitializeServices(services);
            Project.Namespace = Strings.ToValidIdentifier(Path.GetRelativePath(_workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(), ConfigurationsFile).Replace("\\", "."));
        }

        public async Task ReadConfigurations(string filePath = null)
        {
            var busy = await _workflowDesignApi.BusyService.Begin("Loading configurations...");
            filePath = filePath ?? ConfigurationsFile;
            if (filePath == null)
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    FilterIndex = 1,
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    filePath = openFileDialog.FileName;
                    ConfigurationsFile = filePath;
                    _workflowDesignApi.Settings.TrySetValue(SettingKeys.Config_ConfigurationsFilePathKey, filePath);
                }
                else
                {
                    await busy.DisposeAsync();
                    return;
                }
            }
            var raw = await File.ReadAllTextAsync(filePath);
            Project = JsonConvert.DeserializeObject<ProjectModel>(raw) ?? throw new Exception("Could not parse configurations file");
            Project.InitializeServices(_services);
            await busy.DisposeAsync();
        }

        public async Task SaveConfigurations(string filePath = null)
        {
            var busy = await _workflowDesignApi.BusyService.Begin("Saving configurations...");
            filePath = filePath ?? ConfigurationsFile;
            if (filePath == null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    FilterIndex = 1,
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    filePath = saveFileDialog.FileName;
                    ConfigurationsFile = filePath;
                    _workflowDesignApi.Settings.TrySetValue(SettingKeys.Config_ConfigurationsFilePathKey, filePath);
                }
                else
                {
                    await busy.DisposeAsync();
                    return;
                }
            }
            var folder = Path.GetDirectoryName(filePath) ?? throw new Exception("Could not get directory path");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(Project));
            await busy.DisposeAsync();
        }

        public async Task WriteClasses(string filePath = null)
        {
            var busy = await _workflowDesignApi.BusyService.Begin("Generating config classes...");
            filePath = filePath ?? ClassesFile;
            if (filePath == null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSharp files (*.cs)|*.cs",
                    FilterIndex = 1,
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    filePath = saveFileDialog.FileName;
                    ClassesFile = filePath;
                    _workflowDesignApi.Settings.TrySetValue(SettingKeys.Config_ConfigurationTypesFilePathKey, filePath);
                }
                else
                {
                    await busy.DisposeAsync();
                    return;
                }
            }
            var configDir = Path.GetDirectoryName(filePath) ?? throw new Exception("Could not get config directory path");
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            await File.WriteAllTextAsync(filePath, Project.ToNamespaceString());
            await busy.DisposeAsync();


        }

        /// <summary>
        /// Creates an instance of a derived DictionaryWithMembers type from a dictionary of values.
        /// </summary>
        /// <typeparam name="TDerived">The derived type of DictionaryWithMembers to instantiate.</typeparam>
        /// <param name="dictionary">The dictionary containing property values.</param>
        /// <returns>An instance of TDerived populated with values from the dictionary.</returns>
        public TDerived FromDictionary<TDerived>(Dictionary<string, object> dictionary) where TDerived : BaseConfig, new()
        {
            TDerived instance = new();

            // Retrieve all members (properties and fields)
            var members = typeof(TDerived).GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.MemberType == MemberTypes.Property || m.MemberType == MemberTypes.Field);

            foreach (var member in members)
            {
                object parsedValue;

                // Check if the dictionary contains a matching key
                if (!dictionary.TryGetValue(member.Name, out var rawValue))
                    continue;

                if (rawValue is string stringValue)
                {
                    // Get the type of the member
                    var memberType = member is PropertyInfo prop ? prop.PropertyType : ((FieldInfo)member).FieldType;
                    parsedValue = _typeParserService.Parse(stringValue, memberType);
                }
                else
                {
                    // Directly map non-string values
                    parsedValue = rawValue;
                }

                // Set the value
                if (member is PropertyInfo property)
                {
                    property.SetValue(instance, parsedValue);
                }
                else if (member is FieldInfo field)
                {
                    field.SetValue(instance, parsedValue);
                }

                // Add to the instance dictionary
                instance[member.Name] = parsedValue;
            }

            return instance;
        }
    }
}