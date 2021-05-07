using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StaticAnalysisDemo.Linq
{
    internal class Demo1
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

            foreach (var member in root.Members)
            {
                if (member is ClassDeclarationSyntax clazz)
                {
                    var name = clazz.Identifier.Text;
                    
                    Console.WriteLine("Found class with name: " + name);
                }
            }
        }
    }
}