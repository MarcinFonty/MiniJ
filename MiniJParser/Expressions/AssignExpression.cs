using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class AssignExpression : IExpression
    {
        public string _name {  get; }
        public IExpression _right { get; }
        public AssignExpression(string name, IExpression right)
        {
            _name = name;
            _right = right;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("AssignExpression");
            sb.Append(indent).Append("- name " + _name);
            sb.AppendLine();

            sb.Append(indent).Append("- value ");
            _right.Print(sb, indent + "\t");
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitAssignExpression(this);
        }
    }
}
