using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Settings;

namespace GreenLight.DX.Docs.Settings
{
    public static class SettingKeys
    {
        public static string CategoryKey = "GreenLight.DX.Docs";
        public static string SectionKey_General = CategoryKey + ".General";

        public static string SettingKey_General_TemplateRoot = SectionKey_General + ".TemplateRoot";
        public static string SettingKey_General_OutputRoot = SectionKey_General + ".OutputRoot";
        public static string SettingKey_General_IgnoredPaths = SectionKey_General + ".IgnoredPaths";
    }
    public static class Setting
    {

        public static SettingsCategory MainCategory = new SettingsCategory()
        {
            Header = "DX - Docs",
            Key = SettingKeys.CategoryKey,
            Description = "Settings for the auto documentation tool in the DX suite."
        };
        public static SettingsSection GeneralSection = new SettingsSection()
        {
            Key = SettingKeys.SectionKey_General,
            Title = "General",
            Description = "General settings for the auto documentation tool",
            IsExpanded = true
        };
        public static SingleValueEditorDescription<string> OutputRootSetting = new SingleValueEditorDescription<string>()
        {
            DefaultValue = "Documentation",
            Key = SettingKeys.SettingKey_General_OutputRoot,
            Label = "Output Root",
            Description = "The root folder to output the documentation results in. Warning: The entire directory will be recreated every time.",
            GetDisplayValue = (value) => value,
            IsDesignTime = true,
            Validate = (value) => string.IsNullOrWhiteSpace(value) ? "Please set the output folder for auto doc" : null
        };
        public static SingleValueEditorDescription<string> IgnoredPathsSetting = new SingleValueEditorDescription<string>()
        {
            DefaultValue = ".local",
            Key = SettingKeys.SettingKey_General_IgnoredPaths,
            Label = "Ignored Paths",
            Description = "Paths to ignore documentation on.",
            GetDisplayValue = (value) => value,
            IsDesignTime = true,
            Validate = (value) => string.IsNullOrWhiteSpace(value) ? "Please set the ignored folders for auto doc" : null
        };
        public static SingleValueEditorDescription<string> TemplatesRootSetting = new SingleValueEditorDescription<string>()
        {
            DefaultValue = ".docs",
            Key = SettingKeys.SettingKey_General_TemplateRoot,
            Label = "Templates Root",
            Description = "The root for the folder that contains the markdown templates. Must contain Project.md and Workflow.md files.",
            GetDisplayValue = (value) => value,
            IsDesignTime = true,
            Validate = (value) => string.IsNullOrWhiteSpace(value) ? "Please set the templates folder for auto doc" : null
        };



        public static void Create(IWorkflowDesignApi workflowDesignApi)
        {
            var settingsApi = workflowDesignApi.Settings;
            settingsApi.AddCategory(MainCategory);
            settingsApi.AddSection(MainCategory, GeneralSection);
            settingsApi.AddSetting(GeneralSection, OutputRootSetting);
            settingsApi.AddSetting(GeneralSection, IgnoredPathsSetting);
            settingsApi.AddSetting(GeneralSection, TemplatesRootSetting);

            settingsApi.TryGetValue<string>(SettingKeys.SettingKey_General_TemplateRoot, out var templatesRootPath);
            if (!Directory.Exists(templatesRootPath))
            {
                Directory.CreateDirectory(templatesRootPath);
            }
            var projectTemplatePath = Path.Combine(templatesRootPath, "Project.md");
            var workflowTemplatePath = Path.Combine(templatesRootPath, "Workflow.md");
            if (!File.Exists(projectTemplatePath)) File.WriteAllText(projectTemplatePath, Resources.DefaultTemplates.Project);
            if (!File.Exists(workflowTemplatePath)) File.WriteAllText(workflowTemplatePath, Resources.DefaultTemplates.Workflow);
        }
    }
}
