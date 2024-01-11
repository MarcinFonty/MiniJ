using LLVMSharp.Interop;
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
        LLVMValueRef VisitAllExpressions(AllExpressions allExpressions);
        LLVMValueRef VisitAssignExpression (AssignExpression assignExpression);
        LLVMValueRef VisitBinaryOperationExpression(BinaryOperatorExpression binaryOperator);
        LLVMValueRef VisitBlockExpression(BlockExpression blockExpression);
        LLVMValueRef VisitConditionalExpression (ConditionalExpression conditionalExpression);
        LLVMValueRef VisitFunctionCallExpression(FunctionCallExpression callFunctionCallExpression);
        LLVMValueRef VisitFunctionDeclarationExpression(FunctionDeclarationExpression functionDeclaration);
        LLVMValueRef VisitNameExpression(NameExpression nameExpression);
        LLVMValueRef VisitPostfixExpression (PostfixExpression postfixExpression);
        LLVMValueRef VisitPrefixExpression(PrefixExpression prefix);
        LLVMValueRef visitVariableDeclarationExpression (VariableDeclarationExpression variableDeclarationExpression);
    }
}
