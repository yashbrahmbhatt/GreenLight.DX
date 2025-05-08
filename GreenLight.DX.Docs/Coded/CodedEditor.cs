using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs.Coded
{
    public class CodedEditor : BaseEditor
    {
        public SyntaxTree Tree { get; set; }
        public CodedEditor(string filePath) { FilePath = filePath; }

        public async Task Load()
        {
            var raw = await File.ReadAllTextAsync(FilePath);
            Tree = CSharpSyntaxTree.ParseText(raw);
            // Get the root of the syntax tree
            SyntaxNode root = Tree.GetRoot();

            // Create an instance of your walker
            var walker = new Walker();

            // Start the traversal from the root of the syntax tree
            walker.Visit(root);
        }

       
    }
}
