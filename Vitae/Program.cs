﻿using System;
using System.Linq;

using Vitae.CodeAnalysis;

namespace Vitae
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool showTree = false;
            while (true)
            {
                Console.Write("Vitae >> ");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    return;

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees.");
                    continue;
                }

                SyntaxTree syntaxTree = SyntaxTree.Parse(line);
                
                if (showTree)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PrettyPrint(syntaxTree.Root);
                    Console.ForegroundColor = color;
                }

                if (syntaxTree.Diagnostics.Any())
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    
                    foreach (var diagnostic in syntaxTree.Diagnostics)
                    {
                        Console.WriteLine(diagnostic);
                    }

                    Console.ForegroundColor = color;
                }
                else
                {
                    var eval = new Evaluator(syntaxTree.Root);
                    var res = eval.Evaluate();
                    Console.WriteLine(res);
                }
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "")
        {
            Console.Write(indent);
            Console.Write(node.Type);

            if (node is Token t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            Console.WriteLine();

            indent += "    ";

            foreach (var child in node.GetChildren())
                PrettyPrint(child, indent);
        }
    }
}