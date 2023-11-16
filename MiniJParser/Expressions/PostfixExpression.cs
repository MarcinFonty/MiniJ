using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class PostfixExpression : IExpression
    {
        private IExpression mLeft { get; }
        private TokenType mOperator { get; }
        public PostfixExpression(IExpression left, TokenType operatoR)
        {
            mLeft = left;
            mOperator = operatoR;
        }

        public void Print(StringBuilder sb)
        {
            sb.Append('(');
            mLeft.Print(sb);
            sb.Append(mOperator.Punctuator()).Append(')');
        }
    }
}
