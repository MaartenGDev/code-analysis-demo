using System;
using Microsoft.CodeAnalysis.CSharp;

namespace StaticAnalysisDemo.AvailableInformation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var programText = @"
                using System;
                using Example.Two;

                class FirstClass { 
                    public void MethodOne() {
                        Console.WriteLine(1);
                    } 
                } 

                class SecondClass { 
                    public void AnotherMethod() {
                        Console.WriteLine(2);
                        Console.WriteLine(3);
                    } 
                }
                ";

            #region Results
            /*
                Found using statement: using System; [POSITION] line 1 and character 16 until line 1 and character 29
                Found using statement: using Example.Two; [POSITION] line 2 and character 16 until line 2 and character 34
                Found method: MethodOne [POSITION] line 5 and character 20 until line 7 and character 21
                Found method: AnotherMethod [POSITION] line 11 and character 20 until line 14 and character 21
                
                Information starts at index 0
             */
            #endregion
            
            var tree = CSharpSyntaxTree.ParseText(programText);
            var walker = new InformationWalker();

            var root = tree.GetRoot();

            walker.Visit(root);
        }
    }
}