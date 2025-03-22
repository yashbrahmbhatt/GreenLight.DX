using GreenLight.DX.Config.Shared.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using GreenLight.DX.Config.Studio.Services; // Assuming TypeParserService is in this namespace
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using UiPath.Studio.Activities.Api;
using Microsoft.Extensions.DependencyInjection;

namespace GreenLight.DX.Config.Shared.Services
{
    public interface IConfigurationService
    {
        public Project ReadConfigurations();
        public void SaveConfigurations();
        public void WriteClasses();
        public T LoadConfiguration<T>(Configuration config) where T : new();
        public Type[] GetConfigTypes();
    }

    public class ConfigurationService : IConfigurationService
    {
        public Project Project { get; set; }
        public string Root { get; set; }
        public static string ConfigurationsFile { get; set; } = "Configurations.json";
        public static string ClassesFile { get; set; } = "ConfigTypes.cs";
        private readonly IServiceProvider _services;
        private readonly ITypeParserService _typeParserService;
        private readonly IWorkflowDesignApi _workflowDesignApi;


        public ConfigurationService(IServiceProvider services)
        {
            _workflowDesignApi = services.GetRequiredService<IWorkflowDesignApi>();
            _typeParserService = services.GetRequiredService<ITypeParserService>();
            Root = Path.Combine(_workflowDesignApi.ProjectPropertiesService.GetProjectDirectory(), "Configurations");
            Project = new Project();
            Project.Namespace = Helpers.Strings.ToValidIdentifier(_workflowDesignApi.ProjectPropertiesService.GetProjectName() + ".Configurations");
        }

        public Project ReadConfigurations(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(Root))
            {
                throw new Exception("Root must be set before calling ReadConfigurations");
            }
            filePath = filePath ?? Path.Combine(Root, ConfigurationsFile);
            var project = JsonConvert.DeserializeObject<Project>(File.ReadAllText(filePath)) ?? throw new Exception("Could not parse configurations file");
            project.InitializeServices(_services);
            return project;
        }

        public void SaveConfigurations()
        {
            if (string.IsNullOrWhiteSpace(Root))
            {
                throw new Exception("Root must be set before calling SaveConfigurations");
            }
            var filePath = Path.Combine(Root, ConfigurationsFile);
            var configDir = Path.GetDirectoryName(filePath) ?? throw new Exception("Could not get config directory path");
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            File.WriteAllText(filePath, JsonConvert.SerializeObject(Project));
        }

        public void WriteClasses()
        {
            if (string.IsNullOrWhiteSpace(Root))
            {
                throw new Exception("Root must be set before calling SaveConfigurations");
            }
            var filePath = Path.Combine(Root, ClassesFile);
            var configDir = Path.GetDirectoryName(filePath) ?? throw new Exception("Could not get config directory path");
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            File.WriteAllText(filePath, Project.ToNamespaceString());
        }

        public T LoadConfiguration<T>(Configuration config) where T : new()
        {
            T instance = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                ConfigItem configItem = null;
                // Search Settings
                configItem = config.Settings.FirstOrDefault(s => Helpers.Strings.ToValidIdentifier(s.Key) == property.Name);

                // Search Assets if not found in Settings
                if (configItem == null)
                {
                    configItem = config.Assets.FirstOrDefault(a => Helpers.Strings.ToValidIdentifier(a.Key) == property.Name);
                }

                // Search Resources if not found in Settings or Assets
                if (configItem == null)
                {
                    configItem = config.Resources.FirstOrDefault(r => Helpers.Strings.ToValidIdentifier(r.Key) == property.Name);
                }
                if (configItem != null && property.PropertyType == configItem.ValueType)
                {
                    try
                    {
                        property.SetValue(instance, configItem.Value);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error setting property {property.Name}: {ex.Message}");
                    }
                }
            }
            return instance;
        }

        public Type[] GetConfigTypes()
        {
            if (Project == null || Project.Configurations == null)
            {
                return Array.Empty<Type>();
            }

            var types = new System.Collections.Generic.List<Type>();
            var assemblyName = new AssemblyName("DynamicConfigAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicConfigModule");

            foreach (var config in Project.Configurations)
            {
                var className = Helpers.Strings.ToValidIdentifier(config.Name) + "Config";
                var namespaceName = Helpers.Strings.ToValidIdentifier(Project.Namespace);
                var fullTypeName = namespaceName + "." + className;

                var typeBuilder = moduleBuilder.DefineType(fullTypeName, TypeAttributes.Public);

                // Create properties for each ConfigItem
                foreach (var item in config.Settings.ToList<ConfigItem>().Concat(config.Assets).Concat(config.Resources))
                {
                    var propertyName = Helpers.Strings.ToValidIdentifier(item.Key);
                    var propertyType = item.ValueType ?? typeof(object); // Default to object if ValueType is null
                    var propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.None, propertyType, null);

                    var fieldBuilder = typeBuilder.DefineField("_" + propertyName.ToLower(), propertyType, FieldAttributes.Private);

                    // Define getter and setter methods
                    var getMethodBuilder = typeBuilder.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
                    var getIlGenerator = getMethodBuilder.GetILGenerator();
                    getIlGenerator.Emit(OpCodes.Ldarg_0);
                    getIlGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                    getIlGenerator.Emit(OpCodes.Ret);

                    var setMethodBuilder = typeBuilder.DefineMethod("set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { propertyType });
                    var setIlGenerator = setMethodBuilder.GetILGenerator();
                    setIlGenerator.Emit(OpCodes.Ldarg_0);
                    setIlGenerator.Emit(OpCodes.Ldarg_1);
                    setIlGenerator.Emit(OpCodes.Stfld, fieldBuilder);
                    setIlGenerator.Emit(OpCodes.Ret);

                    propertyBuilder.SetGetMethod(getMethodBuilder);
                    propertyBuilder.SetSetMethod(setMethodBuilder);
                }

                var createdType = typeBuilder.CreateType();
                types.Add(createdType);
            }

            return types.ToArray();
        }
    }
}