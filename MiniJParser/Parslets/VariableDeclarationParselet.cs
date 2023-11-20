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
            Token identifier = parser.Consume();
            Token temp = parser.Consume(); //Here's the problem with the todo above, could be resolved with using lookahead instead of Consume, but lookahead is private and not sure if I should be making it public. Gotta ask Herman.
            IExpression assignement = null; //^Parser line 49 for where dirty fix is found^ <-- Parser ParseAllExpressions lookahead stuff I do there.
            if (temp.Type == TokenType.ASSIGN)
            {
                assignement = parser.ParseExpression();
            }
            return new VariableDeclarationExpression(identifier.Text, assignement);
        }
    }
}
