using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastysConsoleUtils
{
    public static class Writer
    {
        /// <summary>
        /// Choose wheter or not to switch beteewn colors every line. Note dose not look good
        /// </summary>
        public static bool alternatingColors = false;
        /// <summary>
        /// First color.
        /// </summary>
        public static ConsoleColor fgColor0 = ConsoleColor.White;
        /// <summary>
        /// Secound color.
        /// </summary>
        public static ConsoleColor fgColor1 = ConsoleColor.DarkGray;
        /// <summary>
        /// Warning text color.
        /// </summary>
        public static ConsoleColor fgWarnColor = ConsoleColor.Yellow;
        /// <summary>
        /// Error text color.
        /// </summary>
        public static ConsoleColor fgErrorColor = ConsoleColor.Red;
        /// <summary>
        /// Background color.
        /// </summary>
        public static ConsoleColor bgColor = ConsoleColor.Black;

        static void AlternateColor()
        {
            if (alternatingColors)
            {
                if (Console.CursorTop % 2 == 0)
                {
                    Console.ForegroundColor = fgColor1;
                }
                else
                {
                    Console.ForegroundColor = fgColor0;
                }
            }
        }

        public static void Warn(string message)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgWarnColor;
            Console.WriteLine(message);

            AlternateColor();
        }

        public static void Error(string message)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgErrorColor;
            Console.WriteLine(message);

            AlternateColor();
        }

        public static void ClearChunk(int startHeight, int stopHeight)
        {
            int cursorTop = Console.CursorTop;
            int cursorLeft = Console.CursorLeft;
            
            Console.SetCursorPosition(0, startHeight);
            for (int i = startHeight; i < stopHeight; i++)
            {
                Console.WriteLine("\b");
            }

            AlternateColor();
            Console.CursorTop = startHeight;
            Console.CursorLeft = cursorLeft;
        }

        public static void Write(object obj, bool timestamp = true)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor0;

            if (timestamp)
                Console.Write($"[{DateTime.Now.TimeOfDay}] {obj}");
            else
                Console.Write(obj);
        }

        public static void WriteLine(object obj, bool timestamp = true)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor0;
            AlternateColor();

            if (timestamp)
                Console.WriteLine($"[{DateTime.Now.TimeOfDay}] {obj}");
            else
                Console.WriteLine(obj);
        }

        public static void WriteLines(object[] obj, bool timestamp = true)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor0;
            foreach (string line in obj)
            {
                WriteLine(line, timestamp);
            }
        }
    }
}
