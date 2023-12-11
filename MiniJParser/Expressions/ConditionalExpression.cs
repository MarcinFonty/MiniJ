using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class ConditionalExpression : IExpression
    {
        public IExpression _condittion { get; }
        public IExpression _thenArm { get; }
        public IExpression _elseArm { get; }
        public ConditionalExpression(IExpression condittion, IExpression thenArm, IExpression elseArm)
        {
            _condittion = condittion;
            _thenArm = thenArm;
            _elseArm = elseArm;
        }

        public void Print(StringBuilder sb, string indent = "")
        {
#warning this needs to be changed into markdown
            sb.Append("(");
            _condittion.Print(sb);
            sb.Append(" ? ");
            _thenArm.Print(sb);
            sb.Append(" : ");
            _elseArm.Print(sb);
            sb.Append(")");
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitConditionalExpression(this);
        }
    }
}
