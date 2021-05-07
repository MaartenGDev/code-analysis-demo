using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.AvailableInformation
{
    public class InformationWalker : CSharpSyntaxWalker
    {
        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            Console.WriteLine($"Found using statement: {node} [POSITION] {GetFormattedLocation(node)}");

            node.SyntaxTree.GetLineSpan(node.Span);

            base.VisitUsingDirective(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            Console.WriteLine($"Found method: {node.Identifier.Text} [POSITION] {GetFormattedLocation(node)}");

            base.VisitMethodDeclaration(node);
        }

        private string GetFormattedLocation(SyntaxNode node)
        {
            var lineSpan = node.SyntaxTree.GetLineSpan(node.Span);
            var startPosition = lineSpan.StartLinePosition;
            var endPosition = lineSpan.EndLinePosition;

            return $"line {startPosition.Line} and character {startPosition.Character} until line {endPosition.Line} and character {endPosition.Character}";
        }
    }
}