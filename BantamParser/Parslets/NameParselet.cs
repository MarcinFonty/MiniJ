using BantamParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Parslets
{
    internal class NameParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            return new NameExpression(token.mText);
        }
    }
}
