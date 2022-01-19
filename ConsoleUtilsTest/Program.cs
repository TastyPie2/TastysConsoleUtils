using static TastysConsoleUtils.ConsoleWriter;
using static TastysConsoleUtils.Prompts;

class Program
{
    static void Main()
    {
        WriteLines(new string[] {"Look", "Ma", "Its", "Alternating", "colors", "do you like it?" });
        
        if(YesNoArrowPrompt(false))
        {
            WriteLine("Thanks.");
        }
        else
        {
            WriteLine("Well i guess its needs more work.");
        }
    }
}
