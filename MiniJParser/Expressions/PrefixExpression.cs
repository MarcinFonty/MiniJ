using System.Text;

namespace MiniJParser.Expressions
{
    internal class PrefixExpression : IExpression //TODO: needs to be revisited later
    {
        private TokenType _operator { get; }
        private IExpression _operand { get; }
        public PrefixExpression(TokenType operatoR, IExpression operand)
        {
            _operator = operatoR;
            _operand = operand;
        }
        public void Print(StringBuilder sb)
        {
            sb.Append('(').Append(_operator.Punctuator());
            _operand.Print(sb);
            sb.Append(")");
        }
    }
}
