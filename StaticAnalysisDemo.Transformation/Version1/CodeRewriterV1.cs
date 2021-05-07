using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Transformation.Version1
{
    public class CodeRewriterV1 : CSharpSyntaxRewriter
    {
        public override SyntaxNode? VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            
            var originalEqualsValue = node.Declaration.Variables[0].Initializer;

            if (originalEqualsValue == null)
            {
                return node;
            }
            
            var value = originalEqualsValue.Value;
            
            if (!(value is LiteralExpressionSyntax))
            {
                return node;
            }

            var updatedEqualsValue = SyntaxFactory.EqualsValueClause(UpdateExpression(value.Kind(), (LiteralExpressionSyntax) value));

            return node.ReplaceNode(originalEqualsValue, updatedEqualsValue);
        }

        private LiteralExpressionSyntax UpdateExpression(SyntaxKind kind,  LiteralExpressionSyntax expression)
        {
            var rawValue = expression.Token.Value;

            if (rawValue == null)
            {
                return expression;
            }
            
            switch (kind)
            {
                case SyntaxKind.NumericLiteralExpression:
                    var nextValue = (int) rawValue + 1;
                    return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(nextValue));
                case SyntaxKind.StringLiteralExpression:
                    var nextStringValue = (string) rawValue + " helloWorld";
                    return SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(nextStringValue));  
                default:
                    return expression;
            }
        }
    }
}