using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal interface IExpression
    {
        public void Print(StringBuilder sb, string indent = "");
    }
}
