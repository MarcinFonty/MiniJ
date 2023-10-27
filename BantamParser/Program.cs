using BantamParser;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {

        //Lexer lexer = new Lexer("9 + 4 * 8 = 49");
        //Lexer lexer = new Lexer("A + C * D + 9 - 12");
        //Lexer lexer = new Lexer("-2 + -4");
        Lexer lexer = new Lexer("A^12^12 - 3 ^a");
        //foreach (Token token in lexer)
        //{
        //    Console.WriteLine(token.mText + " " + token.mType.ToString());
        //    if (token.mType == TokenType.EOF) { break; }
        //}

        //lexer.GetEnumerator(); This is important in my implementation.

        Parser parser = new Parser(lexer.GetEnumerator());

        var result = parser.ParseExpression();
        StringBuilder sb = new StringBuilder();
        result.Print(sb);
        Console.WriteLine(sb.ToString());
    }
}