using BantamParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Parslets
{
    internal class BinaryOperatorParselet : IInfixParselet
    {
        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            IExpression right = parser.ParseExpression();
            return new OperatorExpression(left, token.mType, right);
        }
    }
}
