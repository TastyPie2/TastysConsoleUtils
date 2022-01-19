using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastysConsoleUtils
{
    public static class ConsoleWriter
    {
        public static bool alternatingColors = true;
        public static ConsoleColor fgColor0 = ConsoleColor.White;
        public static ConsoleColor fgColor1 = ConsoleColor.DarkGray;
        public static ConsoleColor fgWarnColor = ConsoleColor.Yellow;
        public static ConsoleColor fgErrorColor = ConsoleColor.Red;
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
            Console.ForegroundColor = fgWarnColor;
            Console.WriteLine(message);

            AlternateColor();
        }

        public static void ClearChunk(int startHeight, int stopHeight)
        {
            Console.SetCursorPosition(0, startHeight);
            for (int i = startHeight; i < stopHeight; i++)
            {
                Console.WriteLine("\b");
            }

            AlternateColor();
        }

        public static void Write(object obj, bool timestamp = true)
        {
            Console.BackgroundColor = bgColor;

            if (timestamp)
                Console.Write($"[{DateTime.Now.TimeOfDay}] {obj}");
            else
                Console.Write(obj);
        }

        public static void WriteLine(object obj, bool timestamp = true)
        {
            Console.BackgroundColor = bgColor;
            AlternateColor();

            if (timestamp)
                Console.WriteLine($"[{DateTime.Now.TimeOfDay}] {obj}");
            else
                Console.WriteLine(obj);
        }

        public static void WriteLines(object[] obj, bool timestamp = true)
        {
            Console.BackgroundColor = bgColor;
            foreach (string line in obj)
            {
                WriteLine(line, timestamp);
            }
        }
    }
}
