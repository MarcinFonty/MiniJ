using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    public enum TokenType
    {
        LEFT_CURLY_BRACKET,
        RIGHT_CURLY_BRAKET,
        SEMICOLON,
        LITERAL,
        //PLUS_ASSING,
        //MINUS_ASSING,
        LESS_THAN,
        GREATER_THAN,
        //LESSER_OR_EQUAL,
        //GREATER_OR_EQUAL,
        //PLUS_PLUS,
        //MINUS_MINUS,

        KEYWORD,
        IDENTIFIER,
        //LET,
        //CONSTANT,
        //IF,
        //ELSE_IF,
        //ELSE,
        //FOR,
        //FUNCTION,
        //RETURN,

        LEFT_PAREN,
        RIGHT_PAREN,
        COMMA,
        ASSIGN,
        PLUS,
        MINUS,
        ASTERISK,
        SLASH,
        CARET,
        TILDE,
        BANG,
        QUESTION,
        COLON,
        EOF,
    }

    public static class TokenTypeExtensions
    {
        public static List<string> Keywords = new List<string> 
        { 
            "let",
            "const",
            "if",
            "else",
            "for",
            "function",
            "return"
        };
        public static char Punctuator(this TokenType type)
        {
            switch (type)
            {
                case TokenType.LEFT_CURLY_BRACKET:
                    return '{';

                case TokenType.RIGHT_CURLY_BRAKET:
                    return '}';

                case TokenType.SEMICOLON:
                    return ';';

                case TokenType.LESS_THAN:
                    return '<';

                case TokenType.GREATER_THAN:
                    return '>';

                case TokenType.LEFT_PAREN:
                    return '(';

                case TokenType.RIGHT_PAREN:
                    return ')';

                case TokenType.COMMA:
                    return ',';

                case TokenType.ASSIGN:
                    return '=';

                case TokenType.PLUS:
                    return '+';

                case TokenType.MINUS:
                    return '-';

                case TokenType.ASTERISK:
                    return '*';

                case TokenType.SLASH:
                    return '/';

                case TokenType.CARET:
                    return '^';

                case TokenType.TILDE:
                    return '~';

                case TokenType.BANG:
                    return '!';

                case TokenType.QUESTION:
                    return '?';

                case TokenType.COLON:
                    return ':';

                case TokenType.EOF:
                default:
                    return '\0';
            }
        }
    }
}
