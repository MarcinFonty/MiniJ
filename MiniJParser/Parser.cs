using MiniJParser.Expressions;
using MiniJParser.Parslets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal class Parser
    {
        private readonly Dictionary<TokenType, IPrefixParselet> _prefixParslet = new Dictionary<TokenType, IPrefixParselet>();
        private readonly Dictionary<TokenType, IInfixParselet> _infixParselet = new Dictionary<TokenType, IInfixParselet>();
        private readonly List<Token> _read = new List<Token>();
        private readonly IEnumerator<Token> _tokens;

        public Parser(IEnumerator<Token> tokens)
        {
            MiniJParser registration = new MiniJParser(this); //This should be done more dynamically instead just MiniJ, to have to posibility of other languages.
            registration.DoRegistration();
            _tokens = tokens;
        }

        public void Register(TokenType token, IPrefixParselet prefix)
        {
            _prefixParslet.Add(token, prefix);
        }

        public void Register(TokenType token, IInfixParselet infix)
        {
            _infixParselet.Add(token, infix);
        }

        public IExpression ParseAllExpression()
        {
            List<IExpression> expressions = new List<IExpression>();

            expressions.Add(ParseExpression());

            Consume(TokenType.SEMICOLON);
            if (TokenType.EOF != LookAhead(0).Type)
            {
                expressions.Add(ParseAllExpression());
            }

            return new AllExpresions(expressions);
        }
        
        public IExpression ParseExpression(int predecece)
        {
            Token token = Consume();
            IPrefixParselet prefix;

            try
            {
                prefix = _prefixParslet[token.Type];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Could not parse \"" + token.Text + "\".");
                throw;
            }

            IExpression left = prefix.Parse(this, token);

            while (predecece < GetPredecene())
            {
                token = Consume();
                IInfixParselet infix = _infixParselet[token.Type];
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
                IInfixParselet parser = _infixParselet[LookAhead(0).Type];
                return parser.getPredecence();
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public bool Match(TokenType expected)
        {
            Token token = LookAhead(0);
            if (token.Type != expected)
            {
                return false;
            }
            Consume();
            return true;
        }

        public Token Consume(TokenType expected)
        {
            Token token = LookAhead(0);
            if(token.Type != expected)
            {
                throw new Exception("Expected token " + expected +" and found " + token.Type);
            }
            return Consume();
        }

        //consume and lookAhead are both taken from git as they arn't explained in the article
        public Token Consume()
        {
            // Make sure we've read the token.
            LookAhead(0);

            //Get the token you want to return
            var result = _read[0];
            _read.RemoveAt(0);

            return result;
        }

        //Returns the token at the requested index
        //Only adds to mRead if you want to look up further than you already did before.
        private Token LookAhead(int distance)
        {
            while (distance >= _read.Count)
            {
                if (_tokens.MoveNext())
                {
                    _read.Add(_tokens.Current);
                }
                else
                {
                    break;
                }
            }

            // Get the queued token.
            return _read[distance];
        }
    }
}
