using BantamParser.Expressions;
using BantamParser.Parslets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BantamParser
{
    internal class Parser
    {
        private readonly Dictionary<TokenType, IPrefixParselet> mPrefixParslet = new Dictionary<TokenType, IPrefixParselet>();
        private readonly List<Token> mRead = new List<Token>();
        private readonly IEnumerator<Token> mTokens;

        public Parser(IEnumerator<Token> tokens)
        {
            Register(TokenType.NAME, new NameParselet());
            Prefix(TokenType.PLUS);
            Prefix(TokenType.MINUS);
            Prefix(TokenType.TILDE);
            Prefix(TokenType.BANG);
            mTokens = tokens;

        }

        public void Register(TokenType token, IPrefixParselet prefix)
        {
            mPrefixParslet.Add(token, prefix);
        }

        public void Prefix(TokenType token)
        {
            Register(token, new PrefixOperatorParselet());
        }
        
        public IExpression ParseExpression() //TODO: Make the parser itself and understand what you're doing
        {
            Token token = Consume();
            IPrefixParselet prefix;

            try
            {
                prefix = mPrefixParslet[token.mType];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Could not parse \"" + token.mText + "\".");
                throw;
            }

            return prefix.Parse(this, token);
        }


        //consume and lookAhead are both taken from git as they arn't explained in the article
        public Token Consume()
        {
            // Make sure we've read the token.
            LookAhead(0);

            //Get the token you want to return
            var result = mRead[0];
            mRead.RemoveAt(0);

            return result;
        }

        //Returns the token at the requested index
        //Only adds to mRead if you want to look up further than you already did before.
        private Token LookAhead(int distance)
        {
            // Read in as many as needed.
            while (distance >= mRead.Count)
            {
                if (mTokens.MoveNext())
                {
                    mRead.Add(mTokens.Current);
                }
                else
                {
                    break;
                }
            }

            // Get the queued token.
            return mRead[distance];
        }
    }
}
