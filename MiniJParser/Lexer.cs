using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniJParser
{
    public class Lexer : IEnumerable<Token>
    {
        private readonly string _text;
        private int _index;
        private readonly Dictionary<char, TokenType> _punctuators = new Dictionary<char, TokenType>();
        private readonly Dictionary<string, TokenType> _keywords = new Dictionary<string, TokenType>();

        public Lexer(string text)
        {
            _index = 0;
            _text = text;

            // Register all of the TokenTypes that are explicit punctuators.
            foreach (TokenType type in Enum.GetValues(typeof(TokenType)))
            {
                char punctuator = type.Punctuator();
                if (punctuator != '\0')
                {
                    _punctuators[punctuator] = type;
                }
            }

            _keywords["let"] = TokenType.LET;
            _keywords["const"] = TokenType.CONSTANT;
            _keywords["if"] = TokenType.IF;
            _keywords["else"] = TokenType.ELSE;
            _keywords["for"] = TokenType.FOR;
            _keywords["function"] = TokenType.FUNCTION;
            _keywords["return"] = TokenType.RETURN;
        }

        public IEnumerator<Token> GetEnumerator()
        {
            while (_index < _text.Length)
            {
                char c = _text[_index++];

                if (_punctuators.ContainsKey(c))
                {
                    // Handle punctuation.
                    yield return new Token(_punctuators[c], c.ToString());
                }
                else if (c == '"')
                {
                    int start = _index -1;
                    while (_index < _text.Length && _text[_index] != '"')
                    {
                        _index++;
                    }

                    if (_index < _text.Length && _text[_index] == '"')
                    {
                        _index++;
                        string literal = _text.Substring(start, _index - start);
                        yield return new Token(TokenType.LITERAL, literal);
                    }
                    else
                    {
                        throw new Exception("No closing quatation found");
                    }
                }
                else if (char.IsDigit(c))
                {
                    // Handle literals.
                    int start = _index - 1;
                    while (_index < _text.Length && char.IsDigit(_text[_index]))
                    {
                        _index++;
                    }

                    string literal = _text.Substring(start, _index - start);

                    yield return new Token(TokenType.LITERAL, literal);
                }
                else if (char.IsLetter(c))
                {
                    // Handle indentifiers.
                    int start = _index - 1;
                    while (_index < _text.Length && (char.IsLetter(_text[_index]) || char.IsDigit(_text[_index])))
                    {
                        _index++;
                    }

                    string identifier = _text.Substring(start, _index - start);

                    if (_keywords.ContainsKey(identifier))
                    {
                        yield return new Token(_keywords[identifier], identifier);
                    } 
                    else
                    {
                        yield return new Token(TokenType.IDENTIFIER, identifier);
                    }
                }
                else
                {
                    // Ignore all other characters (whitespace, etc.)
                }
            }

            while (true)
            {
                yield return new Token(TokenType.EOF, string.Empty);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
