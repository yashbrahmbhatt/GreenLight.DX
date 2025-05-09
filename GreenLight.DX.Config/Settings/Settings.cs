using System;
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

        public static SingleValueEditorDescription<string> ConfigurationJsonPathSetting = new SingleValueEditorDescription<string>()
        {
            DefaultValue = ".config\\Configurations.json",
            Description = "The file path to the configuration file.",
            GetDisplayValue = (value) => value,
            Key = SettingKeys.Config_ConfigurationsFilePathKey,
            Label = "Config File FilePath",
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



        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            var settingsApi = workflowDesignApi.Settings;
            settingsApi.AddCategory(MainCategory);
            settingsApi.AddSection(MainCategory, ConfigSection);
            settingsApi.AddSetting(ConfigSection, ConfigurationJsonPathSetting);
            settingsApi.AddSetting(ConfigSection, ConfigurationClassesPathSetting);
        }
    }
}
