using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class VariableDeclarationExpression : IExpression
    {
        public string _variableName;
        public IExpression _variableValue;
        public VariableDeclarationExpression(string variableName, IExpression variableValue)
        {
            _variableName = variableName;
            _variableValue = variableValue;
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.visitVariableDeclarationExpression(this);
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
