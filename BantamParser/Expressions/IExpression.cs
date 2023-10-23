using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Expressions
{
    internal interface IExpression
    {
        public void Print(StringBuilder sb);
    }
}
