using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Expressions
{
    internal class PrefixExpression : IExpression //TODO: needs to be revisited later
    {
        public TokenType mOperator { get; }
        public IExpression mOperand { get; }
        public PrefixExpression(TokenType operatoR, IExpression operand)
        {
            mOperator = operatoR;
            mOperand = operand;
        }
        public void Print(StringBuilder sb)
        {
            sb.Append('(').Append(mOperator.Punctuator());
            mOperand.Print(sb);
            sb.Append(")");
        }
    }
}
