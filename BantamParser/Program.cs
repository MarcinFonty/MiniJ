using BantamParser;

internal class Program
{
    private static void Main(string[] args)
    {
        Lexer lexer = new Lexer("9 + 4 * 8 = 49");
        //Lexer lexer = new Lexer("A + Hello * C = D");
        foreach (Token token in lexer)
        {
            Console.WriteLine(token.mText + " " + token.mType.ToString());
            if (token.mType == TokenType.EOF) { break; }
        }

        //lexer.GetEnumerator(); This is important in my implementation.
    }
}