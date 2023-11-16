﻿using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class PostfixOperatorParselet : IInfixParselet
    {
        private int mPredecence;
        public PostfixOperatorParselet(int predecence)
        {
            mPredecence = predecence;
        }

        public int getPredecence()
        {
            return mPredecence;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            return new PostfixExpression(left, token.mType);
        }
    }
}
