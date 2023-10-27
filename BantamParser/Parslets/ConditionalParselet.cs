using BantamParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Parslets
{
    internal class ConditionalParselet : IInfixParselet
    {
        public int getPredecence()
        {
            return (int)Precedence.CONDITIONAL;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            IExpression thenArm = parser.ParseExpression();
            parser.Consume(TokenType.COLON);
            IExpression elseArm = parser.ParseExpression((int)Precedence.CONDITIONAL);

            return new Expressions.ConditionalExpression(left, thenArm, elseArm);
        }
    }
}
