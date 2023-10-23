using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantamParser
{
    public enum TokenType
    {
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
        NAME,
        EOF,
        DIGIT,
    }

    public static class TokenTypeExtensions
    {
        public static char Punctuator(this TokenType type)
        {
            switch (type)
            {
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
