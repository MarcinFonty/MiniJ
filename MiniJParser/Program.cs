﻿using MiniJParser;
using System.Globalization;
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

        //Lexer lexer = new Lexer("function AddFunction(x, y) { let z = x + y; return z;};");

        //Lexer lexer = new Lexer("let x = 12;" +
        //    "let y;" +
        //    "let z = x * y;" +
        //    "let g;" +
        //    "g = 12 * 8 + 2;");

        Lexer lexer = new Lexer("function HelloWorld(y) { let x = 12; let result = x + y; };");

        //foreach (Token token in lexer)
        //{
        //    Console.WriteLine(token.Text + " " + token.Type.ToString());
        //    if (token.Type == TokenType.EOF) { break; }
        //}

        Parser parser = new Parser(lexer.GetEnumerator());

        var result = parser.ParseAllExpression();
        StringBuilder sb = new StringBuilder();
        result.Print(sb);
        Console.WriteLine(sb.ToString());
    }
}