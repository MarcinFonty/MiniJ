﻿using BantamParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser.Parslets
{
    internal class PrefixOperatorParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            IExpression operand = parser.ParseExpression();
            return new PrefixExpression(token.mType, operand);
        }
    }
}
