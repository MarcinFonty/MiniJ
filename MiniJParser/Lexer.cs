using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniJParser
{
    public class Lexer : IEnumerable<Token>
    {
        private readonly string _text;
        private int _index;
        private readonly Dictionary<char, TokenType> mPunctuators = new Dictionary<char, TokenType>();

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
                    mPunctuators[punctuator] = type;
                }
            }
        }

        public IEnumerator<Token> GetEnumerator()
        {
            while (_index < _text.Length)
            {
                char c = _text[_index++];

                if (mPunctuators.ContainsKey(c))
                {
                    // Handle punctuation.
                    yield return new Token(mPunctuators[c], c.ToString());
                }
                else if (char.IsLetter(c) || char.IsDigit(c))
                {
                    // Handle literals.
                    int start = _index - 1;
                    while (_index < _text.Length && (char.IsLetter(_text[_index]) || char.IsDigit(_text[_index])))
                    {
                        _index++;
                    }

                    string literal = _text.Substring(start, _index - start);
                    yield return new Token(TokenType.LITERAL, literal);
                }
                //else if (char.IsDigit(c))
                //{
                //    int start = _index - 1;
                //    while (_index < _text.Length && char.IsDigit(_text[_index]))
                //    {
                //        _index++;
                //    }

                //    string digit = _text.Substring(start, _index - start);
                //    yield return new Token(TokenType.LITERAL, digit);
                //}
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
