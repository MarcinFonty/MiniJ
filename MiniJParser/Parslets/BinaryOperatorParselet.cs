using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class BinaryOperatorParselet : IInfixParselet
    {
        private int _predecence;
        private bool _isRight;
        public BinaryOperatorParselet(int predecence, bool isRight)
        {
            _predecence = predecence;
            _isRight = isRight;
        }
        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            IExpression right = parser.ParseExpression(_predecence - (_isRight ? 1 : 0));
            return new BinaryOperatorExpression(left, token.Type, right);
        }

        public int getPredecence()
        {
            return _predecence;
        }
    }
}
