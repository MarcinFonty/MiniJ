using MiniJParser.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class BlockExpression : IExpression //This one is basicaly just AllExpressions, but adds the "BlockExpression"
    {
        private readonly IExpression _expressions;
        public BlockExpression(IExpression expressions)
        {
            _expressions = expressions;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("BlockExpression");
            StringBuilder helperBuilder = new StringBuilder();
            _expressions.Print(helperBuilder, indent + "\t");
            sb.AppendIndented(helperBuilder.ToString(), indent);
        }
    }
}
