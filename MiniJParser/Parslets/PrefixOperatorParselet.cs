using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class PrefixOperatorParselet : IPrefixParselet
    {
        private int _predecence;
        public PrefixOperatorParselet(int predecence)
        {
            _predecence = predecence;
        }

        public IExpression Parse(Parser parser, Token token)
        {
            IExpression operand = parser.ParseExpression(_predecence);
            return new PrefixExpression(token.Type, operand);
        }

        public int GetPredecence()
        {
            return _predecence;
        }
    }
}
