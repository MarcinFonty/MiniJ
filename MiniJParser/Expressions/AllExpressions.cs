using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class AllExpressions : IExpression
    {
        private List<IExpression> _expressions;
        public AllExpressions(List<IExpression> expressions)
        {
            _expressions = expressions;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            foreach (IExpression expression in _expressions)
            {
                expression.Print(sb);
                sb.AppendLine();
            }
        }
    }
}
