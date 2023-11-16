using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class PostfixExpression : IExpression
    {
        private IExpression _left { get; }
        private TokenType _operator { get; }
        public PostfixExpression(IExpression left, TokenType operatoR)
        {
            _left = left;
            _operator = operatoR;
        }

        public void Print(StringBuilder sb)
        {
            sb.Append('(');
            _left.Print(sb);
            sb.Append(_operator.Punctuator()).Append(')');
        }
    }
}
