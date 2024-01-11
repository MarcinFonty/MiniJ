using LLVMSharp.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class BinaryOperatorExpression : IExpression
    {
        public IExpression _left {  get; }
        public TokenType _operator {  get; }
        public IExpression _right { get; }
        public BinaryOperatorExpression(IExpression left, TokenType operatoR, IExpression right)
        {
            _left = left;
            _operator = operatoR;
            _right = right;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("OperatorExpression");

            sb.Append(indent).Append("- left ");
            _left.Print(sb, indent + "\t");
            sb.AppendLine();

            sb.Append(indent + "- operator " + _operator.Punctuator());
            sb.AppendLine();

            sb.Append(indent).Append("- right ");
            _right.Print(sb, indent + "\t");
        }

        public LLVMValueRef AcceptVisitor(IVisitor visitor)
        {
            return visitor.VisitBinaryOperationExpression(this);
        }
    }
}
