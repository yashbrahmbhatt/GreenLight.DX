using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Settings;

namespace GreenLight.DX.Config.Shared
{
    public static class SettingKeys
    {
        public static string CategoryKey = "GreenLight.DX";
        public static string ConfigSectionKey = CategoryKey + ".Config";
        public static string Config_ConfigurationsFilePathKey = ConfigSectionKey + ".ConfigFile";
        public static string Config_ConfigurationTypesFilePathKey = ConfigSectionKey + ".ConfigTypes";
    }
    public static class Settings
    {

        public static SettingsCategory MainCategory = new SettingsCategory()
        {
            Header = "GreenLight Developer Experience",
            Key = SettingKeys.CategoryKey,
            Description = "Settings for all GreenLight Developer Experience tools"
        };
        public static SettingsSection ConfigSection = new SettingsSection()
        {
            Key = SettingKeys.ConfigSectionKey,
            Title = "Config",
            Description = "Settings for the Configuration management tool",
            IsExpanded = true
        };

        

        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            var settingsApi = workflowDesignApi.Settings;
            settingsApi.AddCategory(MainCategory);
            settingsApi.AddSection(MainCategory, ConfigSection);
            settingsApi.AddSetting(ConfigSection, CreateConfigurationFileSetting(workflowDesignApi));
            settingsApi.AddSetting(ConfigSection, CreateConfigurationClassesFileSetting(workflowDesignApi));
        }

        public static SingleValueEditorDescription<string> CreateConfigurationFileSetting(IWorkflowDesignApi api)
        {
            return new SingleValueEditorDescription<string>()
            {
                DefaultValue = Path.Combine(api.ProjectPropertiesService.GetProjectDirectory(), "Configurations", "Configurations.json"),
                Description = "The file path to the configuration file.",
                GetDisplayValue = (value) => value,
                Key = SettingKeys.Config_ConfigurationsFilePathKey,
                Label = "Config File Path",
                IsDesignTime = true,
                Validate = (value) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        return "The configuration file path cannot be empty";
                    }
                    if (!File.Exists(value))
                    {
                        return "The configuration file path does not exist";
                    }
                    return null;
                }
            };  
        }

        public static SingleValueEditorDescription<string> CreateConfigurationClassesFileSetting(IWorkflowDesignApi api)
        {
            return new SingleValueEditorDescription<string>()
            {
                DefaultValue = Path.Combine(api.ProjectPropertiesService.GetProjectDirectory(), "Configurations", "ConfigurationTypes.cs"),
                Description = "The file path to the auto-generated configuration types file.",
                GetDisplayValue = (value) => value,
                Key = SettingKeys.Config_ConfigurationTypesFilePathKey,
                Label = "Types File Path",
                IsDesignTime = true,
                Validate = (value) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        return "The configuration types file path cannot be empty";
                    }
                    if (!File.Exists(value))
                    {
                        return "The configuration types file path does not exist";
                    }
                    return null;
                }
            };
        }
    }
}
