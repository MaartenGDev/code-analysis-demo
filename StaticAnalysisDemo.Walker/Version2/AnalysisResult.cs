using System;
using System.Text;

namespace StaticAnalysisDemo.Walker.Version2
{
    public class AnalysisResult
    {
        public int ClassCount { get; set; }
        public int MethodCount { get; set; }
        public int ExpressionCount { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder()
                .AppendLine("AnalysisResult")
                .AppendLine($"Classes: {ClassCount}")
                .AppendLine($"Methods: {MethodCount}")
                .AppendLine($"Expression: {ExpressionCount}");

            return builder.ToString();
        }
    }
}