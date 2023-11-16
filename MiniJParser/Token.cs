using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    public class Token
    {
        public TokenType mType { get; set; }
        public string mText { get; set; }
        public Token(TokenType Type, String Text)
        {
            mType = Type;
            mText = Text;
        }
    }
}
