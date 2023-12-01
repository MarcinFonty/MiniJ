using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class FunctionDeclarationExpression : IExpression
    {
        private string _name;
        private List<IExpression> _arguments;
        private IExpression _blockExpressions;
        public FunctionDeclarationExpression(string name, List<IExpression> arguments, IExpression blockExpressions)
        {
            _name = name;
            _arguments = arguments;
            _blockExpressions = blockExpressions;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            throw new NotImplementedException();
        }
    }
}
