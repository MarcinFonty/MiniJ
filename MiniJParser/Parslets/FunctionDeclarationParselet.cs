using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class FunctionDeclarationParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            Token identifier = parser.Consume(TokenType.IDENTIFIER);
            parser.Consume(TokenType.LEFT_PAREN);

            List<IExpression> args = new List<IExpression>(); //Duplicate code from FunctionCallParselet, but I think this much duplication is ok.
            if (!parser.Match(TokenType.RIGHT_PAREN))
            {
                do
                {
                    args.Add(parser.ParseExpression());
                } while (parser.Match(TokenType.COMMA));
                parser.Consume(TokenType.RIGHT_PAREN);
            }

            parser.Consume(TokenType.LEFT_CURLY_BRACKET);

            IExpression expressions = null;
            if (!parser.Match(TokenType.RIGHT_CURLY_BRACKET)) //Duplicate code from BlockParselet, but I think this much duplication is ok.
            {
                expressions = parser.ParseAllExpression();
                parser.Consume(TokenType.RIGHT_CURLY_BRACKET);
            }

            return new FunctionDeclarationExpression(identifier.Text, args, expressions);
        }
    }
}
