using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class VariableDeclarationParselet : IPrefixParselet //TODO: Unsure if this should be an infix or a prefix thing.
    {
        public IExpression Parse(Parser parser, Token token)
        {
            Token identifier = parser.Consume(TokenType.IDENTIFIER);
            IExpression assignement = null;
            if (parser.Match(TokenType.ASSIGN))
            {
                assignement = parser.ParseExpression();
            }
            return new VariableDeclarationExpression(identifier.Text, assignement);
        }
    }
}
