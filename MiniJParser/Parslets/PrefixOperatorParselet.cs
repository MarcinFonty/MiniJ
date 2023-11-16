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
        private int mPredecence;
        public PrefixOperatorParselet(int predecence)
        {
            mPredecence = predecence;
        }

        public IExpression Parse(Parser parser, Token token)
        {
            IExpression operand = parser.ParseExpression(mPredecence);
            return new PrefixExpression(token.mType, operand);
        }

        public int GetPredecence()
        {
            return mPredecence;
        }
    }
}
