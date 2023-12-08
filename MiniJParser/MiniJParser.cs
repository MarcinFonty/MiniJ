using MiniJParser.Parslets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal class MiniJParser
    {
        private Parser _parser { get; set; }
        public MiniJParser(Parser parser)
        {
            _parser = parser;
        }

        public void DoRegistration()
        {
            _parser.Register(TokenType.FUNCTION, new FunctionDeclarationParselet());
            
            _parser.Register(TokenType.ASSIGN, new AssignParselet());
            _parser.Register(TokenType.LEFT_CURLY_BRACKET, new BlockParselet());
            _parser.Register(TokenType.LEFT_PAREN, new FunctionCallParselet());
            _parser.Register(TokenType.LET, new VariableDeclarationParselet());
            _parser.Register(TokenType.LITERAL, new NameParselet());
            _parser.Register(TokenType.IDENTIFIER, new NameParselet());
            Prefix(TokenType.PLUS, (int)Precedence.PREFIX);
            Prefix(TokenType.MINUS, (int)Precedence.PREFIX);
            Prefix(TokenType.TILDE, (int)Precedence.PREFIX);
            Prefix(TokenType.BANG, (int)Precedence.PREFIX);
            InfixLeft(TokenType.PLUS, (int)Precedence.SUM);
            InfixLeft(TokenType.MINUS, (int)Precedence.SUM);
            InfixLeft(TokenType.ASTERISK, (int)Precedence.PRODUCT);
            InfixLeft(TokenType.SLASH, (int)Precedence.PRODUCT);
            InfixRight(TokenType.CARET, (int)Precedence.EXPONENT);
        }

        public void Prefix(TokenType token, int precedence)
        {
            _parser.Register(token, new PrefixOperatorParselet(precedence));
        }

        public void InfixLeft(TokenType token, int precedence)
        {
            _parser.Register(token, new BinaryOperatorParselet(precedence, false));
        }
        public void InfixRight(TokenType token, int precedence)
        {
            _parser.Register(token, new BinaryOperatorParselet(precedence, true));
        }
    }
}
