using System;
using System.Collections.Generic;
using System.Linq;

namespace BantamParser
{
    public class Lexer : IEnumerable<Token>
    {
        private readonly string mText;
        private int mIndex;
        private readonly Dictionary<char, TokenType> mPunctuators = new Dictionary<char, TokenType>();

        public Lexer(string text)
        {
            mIndex = 0;
            mText = text;

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
            while (mIndex < mText.Length)
            {
                char c = mText[mIndex++];

                if (mPunctuators.ContainsKey(c))
                {
                    // Handle punctuation.
                    yield return new Token(mPunctuators[c], c.ToString());
                }
                else if (char.IsLetter(c))
                {
                    // Handle names.
                    int start = mIndex - 1;
                    while (mIndex < mText.Length && char.IsLetter(mText[mIndex]))
                    {
                        mIndex++;
                    }

                    string name = mText.Substring(start, mIndex - start);
                    yield return new Token(TokenType.NAME, name);
                }
                else if (char.IsDigit(c))
                {
                    int start = mIndex - 1;
                    while (mIndex < mText.Length && char.IsDigit(mText[mIndex]))
                    {
                        mIndex++;
                    }

                    string digit = mText.Substring(start, mIndex - start);
                    yield return new Token(TokenType.DIGIT, digit);
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
