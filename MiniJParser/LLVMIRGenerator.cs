using LLVMSharp;
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

        private static LLVMIRGenerator instance;
        private LLVMIRGenerator()
        {

            // Get the LLVM context
            LLVMContextRef context = LLVM.GetGlobalContext();

            // Create a module to hold the generated code
            sbyte* moduleName = StringToSBytePointer("MyModule");
            LLVMModuleRef module = LLVM.ModuleCreateWithName(moduleName);

            _module = module;
        }

        public static LLVMIRGenerator GetInstance() //Singelton pattern
        {
            if (instance == null)
            {
                instance = new LLVMIRGenerator();
            }
            return instance;
        }

        public void PrintAndDispose()
        {
            // Print the LLVM IR
            LLVM.DumpModule(_module);

            // Clean up
            LLVM.DisposeModule(_module);
        }

        public sbyte* StringToSBytePointer(string input)
        {
            return (sbyte*)Marshal.StringToHGlobalAnsi(input).ToPointer();
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

            // Check if leftValue is a function
            bool isLeftFunction = LLVM.IsAFunction(leftValue) != default(IntPtr*);

            // Check if rightValue is a function
            bool isRightFunction = LLVM.IsAFunction(rightValue) != default(IntPtr*);

            // Make function calls if necessary
            if (isLeftFunction)
            {
                sbyte* leftCall = StringToSBytePointer("leftCall");
                leftValue = LLVM.BuildCall2(builder, funcType, leftValue, null, 0, leftCall);
                FreeSBytePointer(leftCall);
            }

            if (isRightFunction)
            {
                sbyte* rightCall = StringToSBytePointer("rightCall");
                rightValue = LLVM.BuildCall2(builder, funcType, rightValue, null, 0, rightCall);
                FreeSBytePointer(rightCall);
            }

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

            return BinaryFunction;
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
            if (Int32.TryParse(nameExpression._name, out int variableValue))
            {
                return LLVM.ConstInt(LLVM.Int32Type(), (ulong)variableValue, 0);
            }
            else 
            {
                throw new Exception("Haven't added strings to the compiler yet, so it only works with integers");
            }
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
