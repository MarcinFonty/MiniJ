using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Parslets
{
    internal class AssignParselet : IInfixParselet
    {
        public int getPredecence()
        {
            return (int)Precedence.ASSIGNMENT;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            var right = parser.ParseExpression((int)Precedence.ASSIGNMENT - 1);
            if (!(left is NameExpression))
            {
                throw new Exception("left side in a assignment should be a name");
            }
            var name = ((NameExpression)left)._name;
            return new AssignExpression(name, right);
        }
    }
}
