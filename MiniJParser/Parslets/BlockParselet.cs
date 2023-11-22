using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class BlockParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            IExpression expressions = null;
            if (!parser.Match(TokenType.RIGHT_CURLY_BRACKET))
            {
                expressions = parser.ParseAllExpression();
                parser.Consume(TokenType.RIGHT_CURLY_BRACKET);
            }
            return new BlockExpression(expressions);
        }
    }
}
