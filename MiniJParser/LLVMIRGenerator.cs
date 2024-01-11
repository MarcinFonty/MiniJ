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
            LLVMValueRef mainFunc = LLVM.AddFunction(_module, mainFuncName, funcType);
            FreeSBytePointer(mainFuncName);
            sbyte* entryBlockName = StringToSBytePointer("entry");
            LLVMBasicBlockRef entryBlock = LLVM.AppendBasicBlock(mainFunc, entryBlockName);
            FreeSBytePointer(entryBlockName);

            // Create a builder for generating instructions
            LLVMBuilderRef builder = LLVM.CreateBuilder();
            LLVM.PositionBuilderAtEnd(builder, entryBlock);

            // Declare two integer variables
            LLVMTypeRef intType = LLVM.Int32Type();
            sbyte* leftArm = StringToSBytePointer("leftArm");
            LLVMValueRef left = LLVM.BuildAlloca(builder, intType, leftArm);
            FreeSBytePointer(leftArm);
            sbyte* rightArm = StringToSBytePointer("rightArm");
            LLVMValueRef right = LLVM.BuildAlloca(builder, intType, rightArm);
            FreeSBytePointer(rightArm);

            // Initialize one variable with a value (let's say 5)
            LLVM.BuildStore(builder, LLVM.ConstInt(intType, 5, 0), left);

            // Assign a value to the second variable (let's say 7)
            LLVM.BuildStore(builder, LLVM.ConstInt(intType, 7, 0), right);

            // Load the values of the variables
            sbyte* value1 = StringToSBytePointer("val1");
            LLVMValueRef val1 = LLVM.BuildLoad2(builder, intType, left, value1);
            FreeSBytePointer(value1);
            sbyte* value2 = StringToSBytePointer("val2");
            LLVMValueRef val2 = LLVM.BuildLoad2(builder, intType, right, value2);
            FreeSBytePointer(value2);

            LLVMValueRef result = null;

            switch (binaryOperator._operator)
            {
                case TokenType.PLUS:
                    sbyte* addTemp = StringToSBytePointer("addtmp");
                    result = LLVM.BuildAdd(builder, val1, val2, addTemp);
                    FreeSBytePointer(addTemp);
                    break;
                case TokenType.MINUS:
                    sbyte* subTemp = StringToSBytePointer("subtmp");
                    result = LLVM.BuildSub(builder, val1, val2, subTemp);
                    FreeSBytePointer(subTemp);
                    break;
                case TokenType.ASTERISK:
                    sbyte* mulTemp = StringToSBytePointer("multmp");
                    result = LLVM.BuildMul(builder, val1, val2, mulTemp);
                    FreeSBytePointer(mulTemp);
                    break;
                case TokenType.SLASH:
                    sbyte* divTemp = StringToSBytePointer("divtmp");
                    result = LLVM.BuildSDiv(builder, val1, val2, divTemp); // Use BuildSDiv for signed division
                    FreeSBytePointer(divTemp);
                    break;
                //case TokenType.CARET:
                //    break;
                default:
                    break;
            }

            // Generate the return instruction
            LLVM.BuildRet(builder, result);

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
