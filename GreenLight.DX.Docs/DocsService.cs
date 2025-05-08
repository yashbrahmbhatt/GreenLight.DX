using GreenLight.DX.Docs.Project;
using GreenLight.DX.Docs.Xaml;
using GreenLight.DX.Hermes.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using Microsoft.Extensions.DependencyInjection;
namespace GreenLight.DX.Docs
{
    public class DocsService : HermesConsumer
    {
        public DocsSettings Settings { get; set; }
        public ProjectEditor ProjectEditor { get; set; }
        public List<XamlEditor> XamlEditors { get; set; }
        public DocsService(DocsSettings settings, IServiceProvider provider)
        {
            Settings = settings;
            InitializeLogger(provider, "Docs");
            LoadProject();
            LoadXamls();
        }

        public void LoadProject()
        {
            Info("Loading project...", "LoadProject");
            ProjectEditor = new ProjectEditor(Path.Combine(Settings.ProjectRoot, "project.json"));
            Info("Project loaded", "LoadProject");
        }

        public void LoadXamls()
        {
            Info("Loading xamls...", "LoadXamls");
            var workflowPaths = Directory.GetFiles(Settings.ProjectRoot, "*.xaml", SearchOption.AllDirectories)
                .Where(f =>
                    Settings.IgnoredPaths.Count > 0 ?
                    !Settings.IgnoredPaths.Any(
                        d => Path.GetRelativePath(Settings.ProjectRoot, f).ToLower().Contains(d)
                    ) :
                    true
                ).ToArray();

            XamlEditors = workflowPaths.Select(w => new XamlEditor(w)).ToList();
            foreach (var xamlEditor in XamlEditors) xamlEditor.Load();
            Info("XAMLs loaded", "LoadXamls");

        }

        public void DocumentProject()
        {
            Info("Documenting project...", "DocumentProject");
            var projectTemplate = Path.Combine(Settings.TemplatesRoot, "Project.md");
            var docPath = Path.Combine(Settings.OutputRoot, Settings.ProjectName + ".md");
            if (Directory.Exists(Settings.OutputRoot)) Directory.Delete(Settings.OutputRoot, true);
            Directory.CreateDirectory(Settings.OutputRoot);
            File.WriteAllText(docPath, ProjectEditor.ToMarkdown(projectTemplate));
            Info($"Project documented to '{docPath}'", "DocumentProject");
        }

        public void DocumentWorkflow(XamlEditor editor)
        {
            Info($"Documenting workflow at '{editor.FilePath}'", "DocumentWorkflow");
            var workflowTemplatePath = Path.Combine(Settings.TemplatesRoot, "Workflow.md");
            var workflowTemplate = File.ReadAllText(workflowTemplatePath);
            Debug($"Template used from '{workflowTemplatePath}'", "");
            var docPath = editor.FilePath.Replace(Settings.ProjectRoot, Settings.OutputRoot).Replace(".xaml", ".md");
            var docFolder = Path.GetDirectoryName(docPath);
            if (!Directory.Exists(docFolder)) Directory.CreateDirectory(docFolder);
            File.WriteAllText(docPath, editor.ToMarkdown(workflowTemplate, XamlEditors, ProjectEditor));
            Info($"Workflow documented", "DocumentWorkflow");
        }

        public void Document()
        {
            DocumentProject();
            DocumentWorkflows();
        }

        public void DocumentWorkflows()
        {
            foreach (var editor in XamlEditors) DocumentWorkflow(editor);
        }
    }

    public class DocsSettings
    {
        public string ProjectRoot { get; set; }
        public string OutputRoot { get; set; }
        public string TemplatesRoot { get; set; }
        public List<string> IgnoredPaths { get; set; }

        public string ProjectName { get; set; }
    }
}
