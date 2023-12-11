using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal class LLVMIRGenerator : IVisitor
    {
        public void VisitAllExpressions(AllExpressions allExpressions)
        {
            throw new NotImplementedException();
        }

        public void VisitAssignExpression(AssignExpression assignExpression)
        {
            throw new NotImplementedException();
        }

        public void VisitBinaryOperationExpression(BinaryOperatorExpression binaryOperator)
        {
            throw new NotImplementedException();
        }

        public void VisitBlockExpression(BlockExpression blockExpression)
        {
            throw new NotImplementedException();
        }

        public void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            throw new NotImplementedException();
        }

        public void VisitFunctionCallExpression(FunctionCallExpression callFunctionCallExpression)
        {
            throw new NotImplementedException();
        }

        public void VisitFunctionDeclarationExpression(FunctionDeclarationExpression functionDeclaration)
        {
            throw new NotImplementedException();
        }

        public void VisitNameExpression(NameExpression nameExpression)
        {
            throw new NotImplementedException();
        }

        public void VisitPostfixExpression(PostfixExpression postfixExpression)
        {
            throw new NotImplementedException();
        }

        public void VisitPrefixExpression(PrefixExpression prefix)
        {
            throw new NotImplementedException();
        }

        public void visitVariableDeclarationExpression(VariableDeclarationExpression variableDeclarationExpression)
        {
            throw new NotImplementedException();
        }
    }
}
