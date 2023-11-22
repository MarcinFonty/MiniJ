using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class FunctionCallExpression : IExpression
    {
        private readonly IExpression _functionName;
        private readonly List<IExpression> _argumentsExpressions;
        public FunctionCallExpression(IExpression functionName, List<IExpression> argumentExpressions)
        {
            _functionName = functionName;
            _argumentsExpressions = argumentExpressions;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("FunctionCallExpression");
            sb.Append(indent).Append("- function name ");
            _functionName.Print(sb, indent + "\t");
            sb.AppendLine();
            
            foreach (IExpression argument in _argumentsExpressions)
            {
                sb.Append(indent).Append("- argument ");
                argument.Print(sb, indent + "\t");
                sb.AppendLine();
            }
        }
    }
}
