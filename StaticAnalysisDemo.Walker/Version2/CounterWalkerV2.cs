using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Walker.Version2
{
    public class CounterWalkerV2 : CSharpSyntaxWalker
    {
        private readonly AnalysisResult _result = new AnalysisResult();
        
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            _result.ClassCount++;
            
            base.VisitClassDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            _result.MethodCount++;

            base.VisitMethodDeclaration(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            _result.ExpressionCount++;

            base.VisitInvocationExpression(node);
        }

        public AnalysisResult GetResult()
        {
            return _result;
        }
    }
}