using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal interface IVisitor
    {
        void VisitAllExpressions(AllExpressions allExpressions);
        void VisitAssignExpression (AssignExpression assignExpression);
        void VisitBinaryOperationExpression(BinaryOperatorExpression binaryOperator);
        void VisitBlockExpression(BlockExpression blockExpression);
        void VisitConditionalExpression (ConditionalExpression conditionalExpression);
        void VisitFunctionCallExpression(FunctionCallExpression callFunctionCallExpression);
        void VisitFunctionDeclarationExpression(FunctionDeclarationExpression functionDeclaration);
        void VisitNameExpression(NameExpression nameExpression);
        void VisitPostfixExpression (PostfixExpression postfixExpression);
        void VisitPrefixExpression(PrefixExpression prefix);
        void visitVariableDeclarationExpression (VariableDeclarationExpression variableDeclarationExpression);
    }
}
