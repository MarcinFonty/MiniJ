using LLVMSharp.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class AllExpressions : IExpression
    {
        public List<IExpression> _expressions;
        public AllExpressions(List<IExpression> expressions)
        {
            _expressions = expressions;
        }

        public LLVMValueRef AcceptVisitor(IVisitor visitor)
        {
            return visitor.VisitAllExpressions(this);
        }

        public void Print(StringBuilder sb, string indent = "")
        {
            foreach (IExpression expression in _expressions)
            {
                expression.Print(sb);
                sb.AppendLine();
            }
        }
    }
}
