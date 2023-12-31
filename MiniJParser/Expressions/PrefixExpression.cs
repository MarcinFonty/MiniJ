﻿using System.Text;

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
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("PrefixExpression");

            sb.Append(indent).Append("- operator " + _operator.Punctuator());
            sb.AppendLine();

            sb.Append(indent).Append("- operant ");
            _operand.Print(sb, indent + "\t");
        }
    }
}
