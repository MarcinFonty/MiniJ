using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class VariableDeclarationParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token) //TODO: Ask Herman, Because of how Consume is used, it breaks ParseAllExpresions as it removes the semicolom.
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
