using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Walker.Version1
{
    public class CounterWalkerV1 : CSharpSyntaxWalker
    {
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            Console.WriteLine($"[Walker] Found class with name: {node.Identifier.Text}");
            
            base.VisitClassDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            Console.WriteLine($"[Walker] Found method with name: {node.Identifier.Text}");

            base.VisitMethodDeclaration(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            Console.WriteLine($"[Walker] Found expression: {node}");

            base.VisitInvocationExpression(node);
        }
    }
}