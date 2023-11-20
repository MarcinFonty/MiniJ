using MiniJParser;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //string input = File.ReadAllText("..\\..\\..\\..\\ExampleMiniJ.js");
        //Lexer lexer = new Lexer(input);
        //foreach (Token token in lexer)
        //{
        //    Console.WriteLine(token.Text + " " + token.Type.ToString());
        //    if (token.Type == TokenType.EOF) { break; }
        //}

        Lexer lexer = new Lexer("let x = 12 + 3");

        Parser parser = new Parser(lexer.GetEnumerator());

        var result = parser.ParseExpression();
        StringBuilder sb = new StringBuilder();
        result.Print(sb);
        Console.WriteLine(sb.ToString());
    }
}