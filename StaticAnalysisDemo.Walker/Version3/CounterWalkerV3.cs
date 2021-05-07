using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Walker.Version3
{
    public class CounterWalkerV3 : CSharpSyntaxWalker
    {
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var namespaceDeclaration = node.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
            var namespaceExplanation = namespaceDeclaration == null
                ? " without a namespace"
                : $" within the {namespaceDeclaration.Name} namespace";
            
            Console.WriteLine($"Found class with name {node.Identifier.Text}{namespaceExplanation}");

            base.VisitClassDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var classDeclaration = node.FirstAncestorOrSelf<ClassDeclarationSyntax>();
            
            Console.WriteLine($"Found method with name {node.Identifier.Text} that is in class with name {classDeclaration.Identifier.Text}");
            
            base.VisitMethodDeclaration(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var classDeclaration = node.FirstAncestorOrSelf<ClassDeclarationSyntax>();
            var methodDeclaration = node.FirstAncestorOrSelf<MethodDeclarationSyntax>();

            var argumentCount = node.ArgumentList.Arguments.Count;
            
            Console.WriteLine($"Found {node} expression with {argumentCount} arguments in method with name {methodDeclaration.Identifier.Text} that is in class with name {classDeclaration.Identifier.Text}");

            
            base.VisitInvocationExpression(node);
        }
    }
}