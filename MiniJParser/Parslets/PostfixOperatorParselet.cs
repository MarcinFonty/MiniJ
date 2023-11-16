using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class PostfixOperatorParselet : IInfixParselet
    {
        private int _predecence;
        public PostfixOperatorParselet(int predecence)
        {
            _predecence = predecence;
        }

        public int getPredecence()
        {
            return _predecence;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            return new PostfixExpression(left, token.Type);
        }
    }
}
