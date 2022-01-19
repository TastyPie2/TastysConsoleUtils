using static TastysConsoleUtils.ConsoleWriter;

namespace TastysConsoleUtils
{
    public class Prompts
    {
        private static readonly string arrowRight = "->";
        private static readonly string arrowLeft = "<-";
        private static readonly string arrowUp = @"/\";
        private static readonly string arrowDown = @"\/";

        public static int ListOptions(string[] options, int defultAwnswer = 0)
        {
            Console.WriteLine();
            bool init = false;
            int result = defultAwnswer;
            int dialogStartLine = Console.CursorTop;

            for (int i = 0; i < options.Length; i++)
                options[i] = "{0}" + options[i];

            string[] format = new string[options.Length + 3];

            format[options.Length] = $"Use \"{arrowUp}\" to move selection up and use \"{arrowDown}\" to move down.";
            format[options.Length + 1] = $"Use \"Enter\" to confirm selection.";

            for (; ; )
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == result)
                        format[i] = string.Format(options[i], arrowRight);
                    else
                        format[i] = string.Format(options[i], "  ");
                }

                if (!init)
                {
                    init = true;
                }
                else
                {
                    ClearChunk(dialogStartLine, dialogStartLine + format.Length);
                    Console.CursorTop = dialogStartLine;
                }

                WriteLines(format.ToArray(), false);
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        return result;

                    case ConsoleKey.Escape:
                        return defultAwnswer;

                    case ConsoleKey.UpArrow:
                        result--;
                        break;

                    case ConsoleKey.DownArrow:
                        result++;
                        break;
                }

                if (result < 0)
                    result = options.Length - 1;
                else if (result > options.Length - 1)
                    result = 0;
            }
        }

        public static bool YesNoArrowPrompt(bool defultAwnswer)
        {
            Console.WriteLine();
            bool init = false;
            bool result = defultAwnswer;
            int dialogStartLine = Console.CursorTop;

            for (; ; )
            {
                string[] dialogText = new string[] { "{0}Yes {1}No", $"To select use \"{arrowLeft}\" or \"{arrowRight}\" and to confirm your selection use \"Enter\"" };

                if (result)
                {
                    dialogText[0] = string.Format(dialogText[0], arrowRight, "  ");
                }
                else
                {
                    dialogText[0] = string.Format(dialogText[0], "  ", arrowRight);
                }

                if (!init)
                {
                    init = true;
                }
                else
                {
                    ClearChunk(dialogStartLine, dialogStartLine + dialogText.Length);
                    Console.CursorTop = dialogStartLine;
                }

                WriteLines(dialogText, false);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return false;

                    case ConsoleKey.Enter:
                        return result;

                    case ConsoleKey.Y:
                        return true;

                    case ConsoleKey.N:
                        return false;

                    case ConsoleKey.LeftArrow:
                        result = !result;
                        break;

                    case ConsoleKey.RightArrow:
                        result = !result;
                        break;
                }
            }
        }
    }
}