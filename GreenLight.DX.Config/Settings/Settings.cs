﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Settings;

namespace GreenLight.DX.Config.Settings
{
    public static class SettingKeys
    {
        public static string CategoryKey = "GreenLight.DX.Config";

        public static string ConfigSectionKey = CategoryKey + ".General";

        public static string Config_ConfigurationsFilePathKey = ConfigSectionKey + ".ConfigFile";
        public static string Config_ConfigurationTypesFilePathKey = ConfigSectionKey + ".ConfigTypes";
        public static string Config_ConfigurationTypesNamespaceKey = ConfigSectionKey + ".ConfigTypesNamespace";
    }
    public static class Setting
    {

        public static SettingsCategory MainCategory = new SettingsCategory()
        {
            Header = "DX - Config",
            Key = SettingKeys.CategoryKey,
            Description = "Settings for the config helper tool in the DX suite."
        };
        public static SettingsSection ConfigSection = new SettingsSection()
        {
            Key = SettingKeys.ConfigSectionKey,
            Title = "General",
            Description = "General settings for the config helper tool",
            IsExpanded = true
        };

        public static SingleValueEditorDescription<string> ConfigurationClassesPathSetting = new SingleValueEditorDescription<string>()
        {
            DefaultValue = ".config\\ConfigurationTypes.cs",
            Description = "The file path to the auto-generated configuration types file.",
            GetDisplayValue = (value) => value,
            Key = SettingKeys.Config_ConfigurationTypesFilePathKey,
            Label = "Types File FilePath",
            IsDesignTime = true
        };
        public static SingleValueEditorDescription<string> CreateNamespaceSetting(IWorkflowDesignApi api)
        {
            return new SingleValueEditorDescription<string>()
            {
                DefaultValue = api.ProjectPropertiesService.GetProjectName() + "." + "Config",
                Description = "The namespace for the configuration types",
                GetDisplayValue = (value) => value,
                Key = SettingKeys.Config_ConfigurationTypesNamespaceKey,
                Label = "Config Types Namespace",
                IsDesignTime = true,
            };
        }

        public static SingleValueEditorDescription<string> ConfigurationJsonPathSetting = new SingleValueEditorDescription<string>()
        {
            DefaultValue = ".config\\Configurations.json",
            Description = "The file path to the configuration file.",
            GetDisplayValue = (value) => value,
            Key = SettingKeys.Config_ConfigurationsFilePathKey,
            Label = "Config File FilePath",
            IsDesignTime = true
        };



        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            var settingsApi = workflowDesignApi.Settings;
            settingsApi.AddCategory(MainCategory);
            settingsApi.AddSection(MainCategory, ConfigSection);
            settingsApi.AddSetting(ConfigSection, ConfigurationJsonPathSetting);
            settingsApi.AddSetting(ConfigSection, ConfigurationClassesPathSetting);
            settingsApi.AddSetting(ConfigSection, CreateNamespaceSetting(workflowDesignApi));
        }
    }
}
