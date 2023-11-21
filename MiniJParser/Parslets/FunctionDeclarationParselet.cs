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
            throw new NotImplementedException();
        }
    }
}
