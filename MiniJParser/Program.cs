using MiniJParser;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //string input = File.ReadAllText("C:\\Users\\marci\\Desktop\\Semester 7\\MiniJ\\ExampleMiniJ.js");
        //Lexer lexer = new Lexer(input);
        //foreach (Token token in lexer)
        //{
        //    Console.WriteLine(token.Text + " " + token.Type.ToString());
        //    if (token.Type == TokenType.EOF) { break; }
        //}

        Lexer lexer = new Lexer("-x - 2 = 10 + 2");

        Parser parser = new Parser(lexer.GetEnumerator());

        var result = parser.ParseExpression();
        StringBuilder sb = new StringBuilder();
        result.Print(sb);
        Console.WriteLine(sb.ToString());
    }
}