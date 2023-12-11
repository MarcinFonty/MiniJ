using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class PostfixExpression : IExpression
    {
        public IExpression _left { get; }
        public TokenType _operator { get; }
        public PostfixExpression(IExpression left, TokenType operatoR)
        {
            _left = left;
            _operator = operatoR;
        }

        public void Print(StringBuilder sb, string indent = "")
        {
            sb.Append('(');
            _left.Print(sb);
            sb.Append(_operator.Punctuator()).Append(')');
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitPostfixExpression(this);
        }
    }
}
