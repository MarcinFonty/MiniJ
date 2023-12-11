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

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitNameExpression(this);
        }
    }
}
