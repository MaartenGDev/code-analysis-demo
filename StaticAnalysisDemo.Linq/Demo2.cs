using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Linq
{
    internal class Demo2
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

            foreach (var node in root.Members)
            {
                if (node is MethodDeclarationSyntax methodDeclaration)
                {
                    var name = methodDeclaration.Identifier.Text;
                    
                    Console.WriteLine("Found method with name: " + name);
                }
            }

            #region ExampleTwo
            /*
            foreach (var parent in root.Members)
            {
                if (parent is ClassDeclarationSyntax classDeclaration)
                {
                    var className = classDeclaration.Identifier.Text;
                    Console.WriteLine("Found class with name: " + className);

                    foreach (var child in classDeclaration.Members)
                    {
                        if (child is MethodDeclarationSyntax methodDeclaration)
                        {
                            var methodName = methodDeclaration.Identifier.Text;
                            Console.WriteLine("Found method with name: " + methodName);   
                        }
                    }
                }
            }
            */
            #endregion
        }
    }
}