using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Text { get; set; }
        public Token(TokenType type, string text)
        {
            Type = type;
            Text = text;
        }
    }
}
