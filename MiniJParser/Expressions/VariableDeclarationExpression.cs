using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class VariableDeclarationExpression : IExpression
    {
        private string _variableName;
        private IExpression _variableValue;
        public VariableDeclarationExpression(string variableName, IExpression variableValue)
        {
            _variableName = variableName;
            _variableValue = variableValue;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("VariableDeclarationExpression");

            sb.Append(indent).Append("- variable " + _variableName);
            sb.AppendLine();

            sb.Append(indent).Append("- value ");
            if( _variableValue != null ) 
            {
                _variableValue.Print(sb, indent + "\t");
            } else
            {
                sb.Append("null");
            }
        }
    }
}
