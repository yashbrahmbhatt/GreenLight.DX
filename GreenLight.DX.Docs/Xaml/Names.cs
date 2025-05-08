using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Xaml
{


    static class LocalNames
    {
        public static string IdRef = "WorkflowViewState.IdRef";
        public static string DisplayName = "DisplayName";
        public static string Literal = "Literal";
        public static string CSharpValue = "CSharpValue";
        public static string CSharpReference = "CSharpReference";
        public static string[] Expressions = new string[3] { Literal, CSharpValue, CSharpReference };
        public static string ExpressionType = "TypeArguments";
        public static string Variable = "Variable";
        public static string VariableName = "Name";
        public static string VariableType = "TypeArguments";
        public static string ArgumentDefinition = "Property";
        public static string ArgumentDefinitionName = "Name";
        public static string ArgumentDefinitionType = "Type";
        public static string ArgumentWrapperType = "TypeArguments";
        public static string ArgumentValueType = "TypeArguments";
        public static string LiteralValue = "Value";
        public static string Class = "Class";
        public static string Namespaces = "TextExpression.NamespacesForImplementation";
        public static string References = "TextExpression.ReferencesForImplementation";
        public static string Description = "Annotation.AnnotationText";
        public static string EditingPrefix = "LazyFramework_";
        public static string Editing_Path = EditingPrefix + "FilePath";
    }

    static class NamespaceNames
    {
        public static string X = "{http://schemas.microsoft.com/winfx/2006/xaml}";
        public static string Empty = "{http://schemas.microsoft.com/netfx/2009/xaml/activities}";
    }

}
