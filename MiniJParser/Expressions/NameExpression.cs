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
        public string mName { get; }
        public NameExpression(string name)
        {
            mName = name;
        }

        public void Print(StringBuilder sb)
        {
            sb.Append(mName);
        }
    }
}
