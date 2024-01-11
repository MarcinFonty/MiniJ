using LLVMSharp.Interop;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class NameExpression : IExpression
    {
        public string _name { get; }
        public NameExpression(string name)
        {
            _name = name;
        }

        public void Print(StringBuilder sb, string indent = "")
        {
            sb.Append(_name);
        }

        public LLVMValueRef AcceptVisitor(IVisitor visitor)
        {
            return visitor.VisitNameExpression(this);
        }
    }
}
