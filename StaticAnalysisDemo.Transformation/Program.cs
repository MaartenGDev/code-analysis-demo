using System;
using Microsoft.CodeAnalysis.CSharp;
using StaticAnalysisDemo.Transformation.Version1;

namespace StaticAnalysisDemo.Transformation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var programText = @"
                class FirstClass { 
                    private int _counter = 3;
                    private int _secondCounter = 44;
                    private string _name = ""testing"";
                    private bool _testing = true;

                    public void MethodOne() {
                        Console.WriteLine(1, 2);
                    } 
                } 
                ";
            
            var tree = CSharpSyntaxTree.ParseText(programText);
            var walker = new CodeRewriterV1();

            var root = tree.GetRoot();
            var updatedRoot = walker.Visit(root);
            
            Console.WriteLine(updatedRoot.ToFullString());
        }
    }
}