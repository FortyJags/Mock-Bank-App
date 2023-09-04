using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Bank_App
{
    internal static class ColoredConsole
    {


        /// <summary>
        /// Writes a string on a new line in the given text color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void WriteLineColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        /// <summary>
        /// Changes the text color for user input
        /// </summary>
        /// <param name="color"></param>
        public static void ChangeTypingColor(ConsoleColor color) => Console.ForegroundColor = color;
    }
}
