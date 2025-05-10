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
using GreenLight.DX.Hermes.Services;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using GreenLight.DX.Config.Wizards.Configuration.Windows;
using DocumentFormat.OpenXml.Wordprocessing;

namespace GreenLight.DX.Config.Services.Configuration
{

    public class ConfigurationService : HermesConsumer
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
            InitializeLogger(services, "ConfigurationService");
            _workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationTypesFilePathKey, out var classesPath);
            ClassesFile = classesPath;
            _workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationsFilePathKey, out var configPath);
            ConfigurationsFile = configPath;
            ReadConfigurations();
            Info($"Configuration Service initialized with parameters: '{JsonConvert.SerializeObject(this)}'", "Initialization");
        }

        public void ReadConfigurations(string filePath = null)
        {
            try
            {
                var settings = _workflowDesignApi.Settings;
                settings.TryGetValue<string>(SettingKeys.Config_ConfigurationsFilePathKey, out var configPath);
                ConfigurationsFile = configPath;
                filePath = filePath ?? ConfigurationsFile;
                Info($"Reading configurations from path '{filePath}'", "ReadConfigurations");
                if (!File.Exists(filePath))
                {
                    Debug($"Configuration file doesn't exist", "ReadConfigurations");
                    Project = new ProjectModel(_services);
                    var config = new ConfigurationModel(_services);
                    var setting = new SettingItemModel(_services);
                    setting.Key = "SampleKey";
                    setting.StringValue = "SampleValue";
                    setting.Description = "This is a sample setting configuration. A simple key-value pair.";
                    setting.ValueType = typeof(string);
                    Debug("Here", "ReadConfigurations");
                    config.Settings.Add(setting);
                    Project.Configurations.Add(config);
                    SaveConfigurations();
                    WriteClasses();
                }
                else
                {
                    Debug("Configuration file found", "ReadConfigurations");
                    var raw = File.ReadAllText(filePath);
                    Project = JsonConvert.DeserializeObject<ProjectModel>(raw) ?? throw new Exception("Could not parse configurations file");
                    Project.InitializeServices(_services);
                }
            }
            catch (Exception ex)
            {
                Error("Error: " + ex.Message, "ReadConfigurations");
            }
        }

        public void SaveConfigurations(string filePath = null)
        {
            var settings = _workflowDesignApi.Settings;
            settings.TryGetValue<string>(SettingKeys.Config_ConfigurationsFilePathKey, out var configPath);
            ConfigurationsFile = configPath;
            filePath = filePath ?? ConfigurationsFile;
            if (!File.Exists(filePath))
            {
                var folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
            File.WriteAllText(filePath, JsonConvert.SerializeObject(Project, Formatting.Indented));

        }

        public void WriteClasses(string filePath = null)
        {
            _workflowDesignApi.Settings.TryGetValue<string>(SettingKeys.Config_ConfigurationTypesFilePathKey, out var classesPath);
            ClassesFile = classesPath;
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
                    return;
                }
            }
            var configDir = Path.GetDirectoryName(filePath) ?? throw new Exception("Could not get config directory path");
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            File.WriteAllText(filePath, Project.ToNamespaceString());
        }

        public void Show()
        {
            try
            {
                Info("Showing window", "Show");
                var vm = new MainWindowViewModel(_services);
                var window = new MainWindow(vm);
                window.Show();
            }
            catch (Exception ex)
            {
                Error("Error: " + ex.Message, "Show");
            }
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