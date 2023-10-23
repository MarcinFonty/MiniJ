using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BantamParser.Expressions;

namespace BantamParser.Parslets
{
    internal interface IPrefixParselet
    {
        IExpression Parse(Parser parser, Token token);
    }
}
