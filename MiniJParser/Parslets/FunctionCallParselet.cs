using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class FunctionCallParselet : IInfixParselet
    {
        public int getPredecence()
        {
            return (int)Precedence.CALL;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            List<IExpression> args = new List<IExpression>();
            if (!parser.Match(TokenType.RIGHT_PAREN))
            {
                do
                {
                    args.Add(parser.ParseExpression());
                } while (parser.Match(TokenType.COMMA));
                parser.Consume(TokenType.RIGHT_PAREN);
            }
            return new FunctionCallExpression(left, args);
        }
    }
}
