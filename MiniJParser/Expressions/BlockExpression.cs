using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class BlockExpression : IExpression
    {
        private readonly IExpression _expressions;
        public BlockExpression(IExpression expressions)
        {
            _expressions = expressions;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("BlockExpression");
            _expressions.Print(sb, indent + "\t");
        }
    }
}
