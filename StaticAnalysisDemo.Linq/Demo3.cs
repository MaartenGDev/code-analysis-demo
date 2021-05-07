using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Linq
{
    internal class Demo3
    {
        public void Demo()
        {
            var programText = @"
                class FirstClass { 
                    public void MethodOne() {} 
                } 

                class SecondClass { 
                    public void AnotherMethod() {} 
                }
                ";
            
            var tree = CSharpSyntaxTree.ParseText(programText);
            var root = tree.GetCompilationUnitRoot();

            var childNodes = root.DescendantNodes();
            
            foreach (var node in childNodes)
            {
                if (node is MethodDeclarationSyntax syntax)
                {
                    var name = syntax.Identifier.Text;
                    
                    Console.WriteLine("Found method with name: " + name);
                }
            }
        }
    }
}