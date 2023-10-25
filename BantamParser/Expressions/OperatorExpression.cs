using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Expressions
{
    internal class OperatorExpression : IExpression
    {
        public IExpression mLeft {  get; }
        public TokenType mOperator {  get; }
        public IExpression mRight { get; }
        public OperatorExpression(IExpression left, TokenType operatoR, IExpression right)
        {
            mLeft = left;
            mOperator = operatoR;
            mRight = right;
        }
        public void Print(StringBuilder sb)
        {
            sb.Append('(');
            mLeft.Print(sb);
            sb.Append(' ').Append(mOperator.Punctuator()).Append(' ');
            mRight.Print(sb);
            sb.Append(")");
        }
    }
}
