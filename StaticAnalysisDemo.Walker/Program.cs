using System;
using Microsoft.CodeAnalysis.CSharp;
using StaticAnalysisDemo.Walker.Version1;
using StaticAnalysisDemo.Walker.Version2;
using StaticAnalysisDemo.Walker.Version3;

namespace StaticAnalysisDemo.Walker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var programText = @"
                class FirstClass { 
                    public void MethodOne() {
                        Console.WriteLine(1, 2);
                    } 
                } 

                class SecondClass { 
                    public void AnotherMethod() {
                        Console.WriteLine(3,4,5);
                        Console.WriteLine(6,7);
                    } 
                }
                ";
            
            var tree = CSharpSyntaxTree.ParseText(programText);
            var walker = new CounterWalkerV3();

            var root = tree.GetRoot();

            walker.Visit(root);

            #region PartTwo
            // Console.WriteLine(walker.GetResult());
            #endregion
        }
    }
}