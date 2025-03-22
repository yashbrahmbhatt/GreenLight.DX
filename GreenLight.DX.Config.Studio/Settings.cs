using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Settings;

namespace GreenLight.DX.Config.Studio
{
    public static class SettingKeys
    {
        public static string CategoryKey = "GreenLight.DX";
        public static string ConfigSectionKey = CategoryKey + ".Config";
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
            settingsApi.AddSetting(ConfigSection, CreateRootSetting(workflowDesignApi));
        }

        public static SingleValueEditorDescription<string> CreateRootSetting(IWorkflowDesignApi api)
        {
            return new SingleValueEditorDescription<string>()
            {
                DefaultValue = Path.Combine(api.ProjectPropertiesService.GetProjectDirectory(), "Configurations"),
                Description = "The root folder for the configurations",
                GetDisplayValue = (value) => value,
                Key = SettingKeys.ConfigSectionKey + ".RootFolder",
                Label = "Root Folder",
                Validate = (value) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        return "The root folder cannot be empty";
                    }
                    if (!Directory.Exists(value))
                    {
                        return "The root folder does not exist";
                    }
                    return null;
                }
            };  
        }
    }
}
