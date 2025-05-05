using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Shared.Editor.Coded
{
    public class Walker : CSharpSyntaxWalker
    {
        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            base.VisitNamespaceDeclaration(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            FindAndProcessXmlComments(node);
            base.VisitClassDeclaration(node);
        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            FindAndProcessXmlComments(node);
            base.VisitPropertyDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            FindAndProcessXmlComments(node);
            base.VisitMethodDeclaration(node);
        }

        // Helper method to find and process XML comments attached to a token's leading trivia
        private void FindAndProcessXmlComments(SyntaxNode node)
        {

            // Get the trivia that comes *before* the token
            SyntaxTriviaList leadingTrivia = node.GetLeadingTrivia();

            // Look for XmlDocumentationComment trivia
            var xmlComments = leadingTrivia
                .Where(trivia => trivia.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia) || trivia.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia));
            var stringComments = leadingTrivia
                .Where(trivia => trivia.IsKind(SyntaxKind.SingleLineCommentTrivia) || trivia.IsKind(SyntaxKind.MultiLineCommentTrivia));

            if (xmlComments.Any())
            {
                Console.WriteLine($"      Found XML Comments for {node}:");
                foreach (var commentTrivia in xmlComments)
                {
                    // The FullText includes the /// or /** */ characters
                    // The ToFullString() method on the trivia node gets the raw text
                    Console.WriteLine($"        {commentTrivia.ToFullString().Trim()}");

                    // You can parse the XML content for more detailed analysis
                    // For example, you can get the structure of the XML comment
                    // XmlDocumentationCommentSyntax xmlCommentStructure = commentTrivia.GetStructure() as XmlDocumentationCommentSyntax;
                    // if (xmlCommentStructure != null) { ... analyze elements like <summary>, <param> ... }
                }
            }
        }

        // You can add other Visit methods for other syntax types if needed
        // e.g., VisitStructDeclaration, VisitInterfaceDeclaration, VisitEnumDeclaration, VisitFieldDeclaration etc.
    }
}
