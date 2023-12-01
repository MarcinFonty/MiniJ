using MiniJParser.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class FunctionDeclarationExpression : IExpression
    {
        private string _name;
        private List<IExpression> _parameterExpressions;
        private IExpression _blockExpressions;
        public FunctionDeclarationExpression(string name, List<IExpression> parameterExpressions, IExpression blockExpressions)
        {
            _name = name;
            _parameterExpressions = parameterExpressions;
            _blockExpressions = blockExpressions;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("FunctionDeclarationExpression");

            sb.Append(indent).Append("- name " + _name);
            sb.AppendLine();

            foreach (IExpression parameter in _parameterExpressions)
            {
                sb.Append(indent).Append("- parameter ");
                parameter.Print(sb, indent + "\t");
                sb.AppendLine();
            }

            sb.Append(indent).Append("- BlockExpression");
            sb.AppendLine();
            StringBuilder helperBuilder = new StringBuilder();
            _blockExpressions.Print(helperBuilder, indent + "\t");
            sb.AppendIndented(helperBuilder.ToString(), indent);
        }
    }
}
