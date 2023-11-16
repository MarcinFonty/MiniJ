using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class OperatorExpression : IExpression
    {
        private IExpression _left {  get; }
        private TokenType _operator {  get; }
        private IExpression _right { get; }
        public OperatorExpression(IExpression left, TokenType operatoR, IExpression right)
        {
            _left = left;
            _operator = operatoR;
            _right = right;
        }
        public void Print(StringBuilder sb)
        {
            sb.Append('(');
            _left.Print(sb);
            sb.Append(' ').Append(_operator.Punctuator()).Append(' ');
            _right.Print(sb);
            sb.Append(")");
        }
    }
}
