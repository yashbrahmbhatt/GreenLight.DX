## UiPath Auto-Documentation Wizard

This UiPath wizard provides a convenient way to automatically generate comprehensive documentation for your UiPath projects and individual workflows. By analyzing your project structure and XAML files, it produces Markdown documentation that can be easily integrated into your project's documentation strategy.

### Features

* **Automated Project Documentation:** Generates documentation for the overall UiPath project, including details parsed from the `project.json` file.
* **Automated Workflow Documentation:** Creates individual Markdown files for each analyzed workflow (`.xaml` file), capturing relevant information.
* **Customizable Templates:** Utilizes user-defined Markdown templates for both project and workflow documentation, allowing for tailored output.
* **Configurable Output:** Allows specifying the root directory where the generated documentation will be saved.
* **Exclusion inhaled:** Provides the option to exclude specific paths or directories from the documentation process.
* **Integrated Settings:** Configuration is managed directly within UiPath Studio's settings, offering a seamless user experience.

### Installation

1.  Download the package from the official UiPath Marketplace or your internal package feed.
2.  In UiPath Studio, go to `Manage Packages`.
3.  Select "All Packages" or your configured feed and search for "GreenLight.DX.Docs" (or the specific package name).
4.  Install the package into your UiPath project.

### Usage

Once installed, the Auto-Documentation Wizard can be accessed and triggered within UiPath Studio via a dedicated ribbon button.

Upon execution, the wizard will:

1.  Load the project configuration and settings.
2.  Identify the XAML files within the project, respecting the configured ignored paths.
3.  Generate documentation for the project based on the `Project.md` template.
4.  Generate documentation for each included workflow based on the `Workflow.md` template.
5.  Save the generated Markdown files to the specified output directory.

**Note:** Unfortunately, UiPath's API surface for wizards requires a 'context' to operate on, which results in a prompt before running the wizard to create a new Sequence if no workflow is open within Studio. You must click OK for the wizard to run, but be sure to delete any unnecessary workflows afterwards. If a workflow is open within Studio, this popup will not appear.

### Configuration

The wizard's behavior can be configured via the UiPath Studio settings. Look for a settings category related to "GreenLight.DX.Docs" or "DX - Docs". Within this category, you will find the following settings:

* **Output Root:** Specifies the root folder where the generated documentation Markdown files will be placed. **Warning:** The entire directory will be recreated every time the documentation process is run.
    * **Setting Key:** `GreenLight.DX.Docs.General.OutputRoot`
    * **Default Value:** `Documentation`
* **Ignored Paths:** A comma-separated list of paths (relative to the project root) to ignore during the documentation process. Workflows within these paths will not be documented.
    * **Setting Key:** `GreenLight.DX.Docs.General.IgnoredPaths`
    * **Default Value:** `.local`
* **Templates Root:** Specifies the root folder containing the Markdown templates (`Project.md` and `Workflow.md`) used for generating documentation.
    * **Setting Key:** `GreenLight.DX.Docs.General.TemplateRoot`
    * **Default Value:** `.docs`

When the package is first used or the settings are accessed, default template files (`Project.md` and `Workflow.md`) will be created in the default Templates Root directory if they do not already exist. You can modify these templates to customize the structure and content of your generated documentation.

### Template Usage

The documentation generation relies on Markdown templates. Within these templates, specific variables enclosed in curly braces `{}` will be replaced with information extracted from your UiPath project and workflow files. You can modify these templates (`Project.md` and `Workflow.md`) in the configured **Templates Root** directory to customize the structure and content of your generated documentation.

When the package is first used or the settings are accessed, default template files (`Project.md` and `Workflow.md`) will be created in the specified Templates Root directory if they do not already exist.

Here are the variables available for each template:

**Project Template Variables (`Project.md`)**

| Variable        | Description                                                    |
| :-------------- | :------------------------------------------------------------- |
| `{Name}`        | The name of the UiPath project.                                |
| `{Type}`        | The type of the UiPath project (e.g., Process, Library).     |
| `{Version}`     | The version of the UiPath project.                             |
| `{StudioVersion}`| The UiPath Studio version the project is designed for.       |
| `{Language}`    | The programming language used in the project (e.g., C#, VB.NET).|
| `{Description}` | The description of the project as provided in `project.json`.  |
| `{Dependencies}`| Information about the project's dependencies (likely formatted as a list or table). |
| `{EntryPoints}` | Information about the project's entry point workflows (likely formatted as a list). |

**Workflow Template Variables (`Workflow.md`)**

| Variable          | Description                                                                 |
| :---------------- | :-------------------------------------------------------------------------- |
| `{WorkflowName}`  | The name of the workflow file (e.g., `Main.xaml`).                          |
| `{Class}`         | The class name associated with the workflow (if applicable).                |
| `{Description}`   | The description of the workflow as provided in its annotations.             |
| `{Namespaces}`    | A list of namespaces imported by the workflow.                              |
| `{References}`    | A list of references used by the workflow.                                  |
| `{Arguments}`     | Details about the workflow's arguments (Name, Direction, Type, Description).|
| `{WorkflowsUsed}` | A list of other workflows invoked by this workflow.                         |
| `{UsedByWorkflows}`| A list of workflows that invoke this workflow.                              |
| `{Tests}`         | Information about any associated test cases for this workflow.              |
| `{Outline}`       | A hierarchical outline of the activities within the workflow (Beta feature).|

By using these variables within your Markdown templates, you can customize the generated documentation to include the specific details you need for your UiPath projects and workflows.