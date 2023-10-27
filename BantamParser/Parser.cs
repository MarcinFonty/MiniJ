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
        private readonly Dictionary<TokenType, IInfixParselet> mInfixParselet = new Dictionary<TokenType, IInfixParselet>();
        private readonly List<Token> mRead = new List<Token>();
        private readonly IEnumerator<Token> mTokens;

        public Parser(IEnumerator<Token> tokens)
        {
            Register(TokenType.NAME, new NameParselet());
            Register(TokenType.DIGIT, new NameParselet());
            Prefix(TokenType.PLUS, (int)Precedence.PREFIX);
            Prefix(TokenType.MINUS, (int)Precedence.PREFIX);
            Prefix(TokenType.TILDE, (int)Precedence.PREFIX);
            Prefix(TokenType.BANG, (int)Precedence.PREFIX);
            InfixLeft(TokenType.PLUS, (int)Precedence.SUM);
            InfixLeft(TokenType.MINUS, (int)Precedence.SUM);
            InfixLeft(TokenType.ASTERISK, (int)Precedence.PRODUCT);
            InfixLeft(TokenType.SLASH, (int)Precedence.PRODUCT);
            InfixRight(TokenType.CARET, (int)Precedence.EXPONENT);
            mTokens = tokens;

        }

        public void Register(TokenType token, IPrefixParselet prefix)
        {
            mPrefixParslet.Add(token, prefix);
        }

        public void Register(TokenType token, IInfixParselet infix)
        {
            mInfixParselet.Add(token, infix);
        }

        public void Prefix(TokenType token, int precedence)
        {
            Register(token, new PrefixOperatorParselet(precedence));
        }

        public void InfixLeft(TokenType token, int precedence)
        {
            Register(token, new BinaryOperatorParselet(precedence, false));
        }
        public void InfixRight(TokenType token, int precedence)
        {
            Register(token, new BinaryOperatorParselet(precedence, true));
        }
        
        public IExpression ParseExpression(int predecece)
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

            IExpression left = prefix.Parse(this, token);

            while (predecece < GetPredecene())
            {
                token = Consume();
                IInfixParselet infix = mInfixParselet[token.mType];
                left = infix.Parse(this, left, token);
            }

            return left;
        }

        public IExpression ParseExpression()
        {
            return ParseExpression(0);
        }

        private int GetPredecene()
        {
            try
            {
                IInfixParselet parser = mInfixParselet[LookAhead(0).mType];
                return parser.getPredecence();
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public Token Consume(TokenType expected)
        {
            Token token = LookAhead(0);
            if(token.mType != expected)
            {
                throw new Exception("Expected token " + expected +" and found " + token.mType);
            }
            return Consume();
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
            while (distance >= mRead.Count) //TODO: I have a feeling like the mRead state should be reset or at least moven forward once the parsing process processes. But unsure for now.
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
