using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Expressions
{
    internal class ConditionalExpression : IExpression
    {
        public IExpression mCondittion { get; }
        public IExpression mThenArm { get; }
        public IExpression mElseArm { get; }
        public ConditionalExpression(IExpression condittion, IExpression thenArm, IExpression elseArm)
        {
            mCondittion = condittion;
            mThenArm = thenArm;
            mElseArm = elseArm;
        }

        public void Print(StringBuilder sb)
        {
            sb.Append("(");
            mCondittion.Print(sb);
            sb.Append(" ? ");
            mThenArm.Print(sb);
            sb.Append(" : ");
            mElseArm.Print(sb);
            sb.Append(")");
        }
    }
}
