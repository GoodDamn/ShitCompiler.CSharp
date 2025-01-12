﻿using System.Xml.Schema;
using ShitCompiler.Lexicon;

namespace ShitCompiler;

class Program
{
    static void Main(string[] args)
    {
        string testInput = """
                           :
                           var abs = abstrd;
                           
                           ["Строка" 'с' 'Инвалид'] 
                           // Это скипаем () ][
                           /*
                           Тут тоже будет скип
                           */
                           / 
                           |
                           &
                           &&
                           ||
                           >>
                           >=
                           <=
                           +-*
                           {[()]}
                           /* А это инвалид                               
                           """;
        Console.WriteLine(testInput);
        TextCursor cursor = new(testInput.AsMemory());
        ILexer lexer = new SimpleLexer(cursor);

        while (true)
        {
            Lexeme lexeme = lexer.ScanNext();
            Console.WriteLine(lexeme);
            if (lexeme.Kind == LexemeKind.EndToken) 
                break;
        }

        Console.WriteLine("Hello, World!");
    }
}