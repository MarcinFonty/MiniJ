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
        private int mPredecence;
        private bool mIsRight;
        public BinaryOperatorParselet(int predecence, bool isRight)
        {
            mPredecence = predecence;
            mIsRight = isRight;
        }
        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            IExpression right = parser.ParseExpression(mPredecence - (mIsRight ? 1 : 0));
            return new OperatorExpression(left, token.mType, right);
        }

        public int getPredecence()
        {
            return mPredecence;
        }
    }
}
