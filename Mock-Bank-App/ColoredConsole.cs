using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Bank_App
{
    internal static class ColoredConsole
    {



        public static void WriteLineColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color; Console.WriteLine(text);
        }


        public static void ChangeTypingColor(ConsoleColor color) => Console.ForegroundColor = color;
    }
}
