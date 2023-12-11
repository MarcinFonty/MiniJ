using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal class LLVMIRGenerator //this is a form of tge visitor pattern, as it receives the IExpression objects to generate the IR instead of having this logic inside the expressions.
    {
        public string GenerateIR(IExpression root)
        {
            switch (root)
            {
                case AssignExpression assign when assign != null:
                    GenerateForAssignExpression(assign);
                    break;
                case BlockExpression block when block != null:
                case ConditionalExpression conditional when conditional != null:
                case FunctionCallExpression functionCall when functionCall != null:
                case FunctionDeclarationExpression functionDeclaration when functionDeclaration != null:
                case NameExpression name when name != null:
                case BinaryOperatorExpression binaryOperator when binaryOperator != null:
                case PostfixExpression postfix when postfix != null:
                case PrefixExpression prefix when prefix != null:
                case VariableDeclarationExpression variableDeclaration when variableDeclaration != null:
                    throw new NotImplementedException();
                default:
                    throw new Exception("Not recognized/registered expression to make IR from");
            }
            throw new NotImplementedException();
        }

        private string GenerateForAssignExpression(AssignExpression assign)
        {
            throw new NotImplementedException();
        }
    }
}
