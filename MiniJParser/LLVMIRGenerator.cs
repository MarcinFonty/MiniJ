using LLVMSharp.Interop;
using MiniJParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal unsafe class LLVMIRGenerator : IVisitor
    {
        LLVMModuleRef _module { get; set; }
        public LLVMIRGenerator()
        {

            // Get the LLVM context
            LLVMContextRef context = LLVM.GetGlobalContext();

            // Create a module to hold the generated code
            sbyte* moduleName = StringToSBytePointer("MyModule");
            LLVMModuleRef module = LLVM.ModuleCreateWithName(moduleName);

            _module = module;
        }

        public sbyte* StringToSBytePointer(string input)
        {
            int length = Encoding.ASCII.GetByteCount(input);
            byte[] byteArray = new byte[length + 1]; // +1 for null termination
            Encoding.ASCII.GetBytes(input, 0, input.Length, byteArray, 0);
            fixed (byte* p = byteArray)
            {
                return (sbyte*)p;
            }
        }

        public void FreeSBytePointer(sbyte* pointer)
        {
            IntPtr ptr = (IntPtr)pointer;
            Marshal.FreeHGlobal(ptr);
        }

        public LLVMValueRef VisitAllExpressions(AllExpressions allExpressions)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitAssignExpression(AssignExpression assignExpression)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitBinaryOperationExpression(BinaryOperatorExpression binaryOperator)
        {
            // Define the function signature
            LLVMTypeRef[] paramTypes = { LLVM.Int32Type(), LLVM.Int32Type() };
            LLVMOpaqueType** paramTypesPtr = stackalloc LLVMOpaqueType*[paramTypes.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                paramTypesPtr[i] = paramTypes[i];
            }
            LLVMTypeRef funcType = LLVM.FunctionType(LLVM.Int32Type(), paramTypesPtr, (uint)paramTypes.Length, 0);
            sbyte* mainFuncName = StringToSBytePointer("BinaryFunction");
            LLVMValueRef BinaryFunction = LLVM.AddFunction(_module, mainFuncName, funcType);
            FreeSBytePointer(mainFuncName);
            sbyte* entryBlockName = StringToSBytePointer("entry");
            LLVMBasicBlockRef entryBlock = LLVM.AppendBasicBlock(BinaryFunction, entryBlockName);
            FreeSBytePointer(entryBlockName);

            // Create a builder for generating instructions
            LLVMBuilderRef builder = LLVM.CreateBuilder();
            LLVM.PositionBuilderAtEnd(builder, entryBlock);

            // Load the values of the variables
            LLVMValueRef leftValue = binaryOperator._left.AcceptVisitor(this);
            LLVMValueRef rightValue = binaryOperator._right.AcceptVisitor(this);

            LLVMValueRef result = null;

            switch (binaryOperator._operator)
            {
                case TokenType.PLUS:
                    sbyte* addTemp = StringToSBytePointer("addtmp");
                    result = LLVM.BuildAdd(builder, leftValue, rightValue, addTemp);
                    FreeSBytePointer(addTemp);
                    break;
                case TokenType.MINUS:
                    sbyte* subTemp = StringToSBytePointer("subtmp");
                    result = LLVM.BuildSub(builder, leftValue, rightValue, subTemp);
                    FreeSBytePointer(subTemp);
                    break;
                case TokenType.ASTERISK:
                    sbyte* mulTemp = StringToSBytePointer("multmp");
                    result = LLVM.BuildMul(builder, leftValue, rightValue, mulTemp);
                    FreeSBytePointer(mulTemp);
                    break;
                case TokenType.SLASH:
                    sbyte* divTemp = StringToSBytePointer("divtmp");
                    result = LLVM.BuildSDiv(builder, leftValue, rightValue, divTemp); // Use BuildSDiv for signed division
                    FreeSBytePointer(divTemp);
                    break;
                //case TokenType.CARET:
                //    break;
                default:
                    break;
            }

            // Generate the return instruction
            LLVM.BuildRet(builder, result);

            //LLVM.DeleteFunction(BinaryFunction); <--- Really don't understand this one
            LLVM.DisposeBuilder(builder);

            return null;
        }

        public LLVMValueRef VisitBlockExpression(BlockExpression blockExpression)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitFunctionCallExpression(FunctionCallExpression callFunctionCallExpression)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitFunctionDeclarationExpression(FunctionDeclarationExpression functionDeclaration)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitNameExpression(NameExpression nameExpression)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitPostfixExpression(PostfixExpression postfixExpression)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef VisitPrefixExpression(PrefixExpression prefix)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef visitVariableDeclarationExpression(VariableDeclarationExpression variableDeclarationExpression)
        {
            throw new NotImplementedException();
        }
    }
}
